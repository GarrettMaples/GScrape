using GScrape.Results;
using MediatR;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape
{
    public class NotificationCacheBehavior<T> : IPipelineBehavior<ScrapeResult<T>, Unit> where T : ScrapeItem
    {
        protected ConcurrentDictionary<string, ConcurrentDictionary<string, ScrapeCacheItem>> Cache { get; } = new ConcurrentDictionary<string, ConcurrentDictionary<string, ScrapeCacheItem>>();
        private readonly IEmailer _emailer;
        private readonly IConfiguration _configuration;

        public NotificationCacheBehavior(IEmailer emailer, IConfiguration configuration)
        {
            _emailer = emailer;
            _configuration = configuration;
        }

        public async Task<Unit> Handle(ScrapeResult<T> request, CancellationToken cancellationToken, RequestHandlerDelegate<Unit> next)
        {
            var requestScrapeItems = await request.ScrapeItems.ToListAsync(cancellationToken);
            var newScrapeItems = GetScrapeItemsToNotifyAbout(request.ResultId, requestScrapeItems).ToList();

            await Notify(request, requestScrapeItems, cancellationToken);
            PopulateCache(request, requestScrapeItems, newScrapeItems);

            // Update request object
            request.ScrapeItems = newScrapeItems.ToAsyncEnumerable();

            return await next();
        }

        protected virtual IEnumerable<T> GetScrapeItemsToNotifyAbout(string resultId, ICollection<T> requestScrapeItems)
        {
            if (!requestScrapeItems.Any())
            {
                yield break;
            }

            if (Cache.ContainsKey(resultId))
            {
                foreach (var scrapeItem in requestScrapeItems)
                {
                    if (!Cache[resultId].ContainsKey(scrapeItem.ItemId))
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

        protected virtual async Task Notify(ScrapeResult<T> request, IEnumerable<T> scrapeItems, CancellationToken cancellationToken)
        {
            if (!Cache.ContainsKey(request.ResultId))
            {
                return;
            }

            var newScrapeItemIds = scrapeItems.Select(x => x.ItemId).ToList();
            var existingScrapeItemIds = Cache[request.ResultId].Keys;

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
                    $"Name: {Cache[request.ResultId][result].Item.Name}{Environment.NewLine}Link: {Cache[request.ResultId][result].Item.Link}{Environment.NewLine}");
            }

            var bodyBuilder = new BodyBuilder { TextBody = stringBuilder.ToString() };
            message.Body = bodyBuilder.ToMessageBody();

            await _emailer.SendEmail(message, cancellationToken);
        }

        protected virtual void PopulateCache(ScrapeResult<T> request, IEnumerable<T> scrapeItems, IEnumerable<T> notificationItems)
        {
            var requestCache = Cache.GetOrAdd(request.ResultId, new ConcurrentDictionary<string, ScrapeCacheItem>());
            
            foreach (var scrapeItem in notificationItems)
            {
                var scrapeCacheItem = new ScrapeCacheItem(scrapeItem);
                requestCache.AddOrUpdate(scrapeItem.ItemId, scrapeCacheItem, (s, item) => scrapeCacheItem );
            }
        }

        protected class ScrapeCacheItem
        {
            public ScrapeCacheItem(T item, DateTime? lastUpdated = null)
            {
                Item = item;
                LastUpdated = lastUpdated ?? DateTime.Now;
            }

            public T Item { get; }

            public DateTime LastUpdated { get; }
        }
    }
}