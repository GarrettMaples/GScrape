using GScrape.Results;
using MediatR;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape
{
    public class NotificationCacheBehavior : IPipelineBehavior<ScrapeResult, Unit>
    {
        private readonly Dictionary<string, ScrapeCache> _cache = new Dictionary<string, ScrapeCache>();
        private readonly IEmailer _emailer;
        private readonly IConfiguration _configuration;

        public NotificationCacheBehavior(IEmailer emailer, IConfiguration configuration)
        {
            _emailer = emailer;
            _configuration = configuration;
        }

        public async Task<Unit> Handle(ScrapeResult request, CancellationToken cancellationToken, RequestHandlerDelegate<Unit> next)
        {
            var requestScrapeItems = await request.ScrapeItems.ToListAsync(cancellationToken);
            var newScrapeItems = BuildNewScrapeItems(request.ResultId, requestScrapeItems).ToList();

            await NotifyOutOfStock(request, requestScrapeItems, cancellationToken);
            PopulateInStockCache(request, newScrapeItems);

            // Update request object
            request.ScrapeItems = newScrapeItems.ToAsyncEnumerable();

            return await next();
        }

        private IEnumerable<ScrapeItem> BuildNewScrapeItems(string resultId, ICollection<ScrapeItem> requestScrapeItems)
        {
            if (!requestScrapeItems.Any())
            {
                yield break;
            }

            if (_cache.ContainsKey(resultId))
            {
                foreach (var scrapeItem in requestScrapeItems)
                {
                    if (!_cache[resultId].ScrapeCacheItems.ContainsKey(scrapeItem.ItemId))
                    {
                        yield return scrapeItem;
                    }
                }
            }
            else
            {
                foreach (var scrapeItem in requestScrapeItems)
                {
                    yield return scrapeItem;
                }
            }
        }

        private async Task NotifyOutOfStock(ScrapeResult request, IEnumerable<ScrapeItem> scrapeItems, CancellationToken cancellationToken)
        {
            if (!_cache.ContainsKey(request.ResultId))
            {
                return;
            }

            var newScrapeItemIds = scrapeItems.Select(x => x.ItemId).ToList();
            var existingScrapeItemIds = _cache[request.ResultId].ScrapeCacheItems.Keys;

            var itemsToRemove = existingScrapeItemIds.Except(newScrapeItemIds).ToList();

            if (!itemsToRemove.Any())
            {
                return;
            }

            var message = new MimeMessage();

            var from = new MailboxAddress("no-reply", "no-reply@gscraper.com");
            message.From.Add(from);

            foreach (var email in _configuration.GetValue<string>("ToEmailAddresses").Split(','))
            {
                var to = new MailboxAddress("User", email);
                message.To.Add(to);
            }

            message.Subject = $"{request.RequestName} Items No Longer In Stock!";

            var stringBuilder = new StringBuilder();
            foreach (var result in itemsToRemove)
            {
                stringBuilder.AppendLine(
                    $"Name: {_cache[request.ResultId].ScrapeCacheItems[result].ItemName}{Environment.NewLine}Link: {_cache[request.ResultId].ScrapeCacheItems[result].ItemLink}{Environment.NewLine}");
            }

            var bodyBuilder = new BodyBuilder { TextBody = stringBuilder.ToString() };
            message.Body = bodyBuilder.ToMessageBody();

            await _emailer.SendEmail(message, cancellationToken);
        }

        private void PopulateInStockCache(ScrapeResult request, IEnumerable<ScrapeItem> newScrapeItems)
        {
            var now = DateTime.Now;
            var newScrapeCacheItems = new Dictionary<string, ScrapeCacheItem>();

            foreach (var scrapeItem in newScrapeItems)
            {
                newScrapeCacheItems.Add(scrapeItem.ItemId, new ScrapeCacheItem(scrapeItem.ItemName, scrapeItem.ItemLink, scrapeItem.ItemId, now));
            }

            if (_cache.TryAdd(request.ResultId, new ScrapeCache(request.RequestName, newScrapeCacheItems)))
            {
                return;
            }

            _cache[request.ResultId] = new ScrapeCache(request.RequestName, newScrapeCacheItems);
        }

        private class ScrapeCache
        {
            public ScrapeCache(string requestName, Dictionary<string, ScrapeCacheItem> scrapeCacheItems)
            {
                RequestName = requestName;
                ScrapeCacheItems = scrapeCacheItems;
            }

            public string RequestName { get; }
            public Dictionary<string, ScrapeCacheItem> ScrapeCacheItems { get; }
        }

        private class ScrapeCacheItem : ScrapeItem
        {
            public ScrapeCacheItem(string itemName, string itemLink, string itemId, DateTime lastInStock) : base(itemName, itemLink, itemId)
            {
                LastInStock = lastInStock;
            }

            public DateTime LastInStock { get; }
        }
    }
}