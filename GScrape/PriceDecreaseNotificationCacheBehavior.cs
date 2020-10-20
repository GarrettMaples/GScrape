using GScrape.Results;
using Microsoft.Extensions.Configuration;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape
{
    public class PriceDecreaseNotificationCacheBehavior : NotificationCacheBehavior<ItemPriceScrapeItem>
    {
        public PriceDecreaseNotificationCacheBehavior(IEmailer emailer, IConfiguration configuration)
            : base(emailer, configuration)
        {
        }

        protected override IEnumerable<ItemPriceScrapeItem> GetScrapeItemsToNotifyAbout(string resultId, ICollection<ItemPriceScrapeItem> requestScrapeItems)
        {
            if (!requestScrapeItems.Any())
            {
                yield break;
            }

            if (!Cache.ContainsKey(resultId))
            {
                yield break;
            }

            foreach (var scrapeItem in requestScrapeItems)
            {
                if (Cache[resultId].ContainsKey(scrapeItem.ItemId) && Cache[resultId][scrapeItem.ItemId].Item.Price > scrapeItem.Price)
                {
                    yield return scrapeItem;
                }
            }
        }
        
        protected override void PopulateCache(ScrapeResult<ItemPriceScrapeItem> request, IEnumerable<ItemPriceScrapeItem> scrapeItems, IEnumerable<ItemPriceScrapeItem> notificationItems)
        {
            var requestCache = Cache.GetOrAdd(request.ResultId, new ConcurrentDictionary<string, ScrapeCacheItem>());
            
            foreach (var scrapeItem in scrapeItems)
            {
                var scrapeCacheItem = new ScrapeCacheItem(scrapeItem);
                requestCache.AddOrUpdate(scrapeItem.ItemId, scrapeCacheItem, (s, item) => scrapeCacheItem );
            }
        }

        protected override async Task Notify(ScrapeResult<ItemPriceScrapeItem> request, IEnumerable<ItemPriceScrapeItem> scrapeItems, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}