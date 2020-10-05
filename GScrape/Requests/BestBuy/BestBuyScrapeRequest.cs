using GScrape.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;

namespace GScrape.Requests.BestBuy
{
    public class BestBuyScrapeRequest : IRequest<IAsyncEnumerable<ScrapeResult>>
    {
    }

    internal class BestBuyScrapeRequestHandler : RequestHandler<BestBuyScrapeRequest, IAsyncEnumerable<ScrapeResult>>
    {
        private static readonly Regex _itemFulfillmentRegex = new Regex(@"initializer.initializeComponent\({""creatorNamespace"":""fulfillment"".*?""({\\""app.+?}})"",",
            RegexOptions.Compiled | RegexOptions.IgnoreCase,
            TimeSpan.FromSeconds(10));

        private static readonly Regex _itemShopRegex = new Regex(
            @"initializer.initializeComponent\({""creatorNamespace"":""shop"".*?""contractVersion"":""v2"".*?""({\\""app.+?}})"",",
            RegexOptions.Compiled | RegexOptions.IgnoreCase,
            TimeSpan.FromSeconds(10));

        private readonly IMediator _mediator;
        private readonly ILogger<BestBuyScrapeRequestHandler> _logger;
        private readonly HttpClient _httpClient;
        internal static readonly string BestBuyBaseUrl = "https://www.bestbuy.com";

        public BestBuyScrapeRequestHandler(IMediator mediator, ILogger<BestBuyScrapeRequestHandler> logger, HttpClient httpClient)
        {
            _mediator = mediator;
            _logger = logger;
            _httpClient = httpClient;
        }

        protected override async IAsyncEnumerable<ScrapeResult> Handle(BestBuyScrapeRequest request)
        {
            var searchRequest = new BestBuyItemSearchRequest();

            var searches = await _mediator.Send(searchRequest);

            await foreach (var search in searches)
            {
                var scrapeItems = GetItems(search.Html);

                yield return new ScrapeResult(search.Name, scrapeItems.ToAsyncEnumerable());
            }
        }

        private IEnumerable<ScrapeItem> GetItems(string htmlItemPage)
        {
            var itemFulfillmentCollection = Get<ItemFulfillmentJson>(_itemFulfillmentRegex.Matches(htmlItemPage)).ToList();
            var itemShopJsonDictionary = GetItemShopJsonDictionary(_itemShopRegex.Matches(htmlItemPage));

            _logger.LogInformation($"{itemFulfillmentCollection.Count} item matches found.");

            foreach (var item in itemFulfillmentCollection)
            {
                if (!item.ButtonState_.BSState.Contains("ADD_TO_CART", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var itemLink = new Uri(new Uri(BestBuyBaseUrl), HttpUtility.UrlDecode(item.App_.SkuPdpUrl.Replace(@"\u002F", @"\")));

                var itemId = item.Items_.FirstOrDefault()?.SkuId;

                var itemName = string.Empty;
                if (!string.IsNullOrWhiteSpace(itemId) && itemShopJsonDictionary.TryGetValue(itemId, out var itemShopJson))
                {
                    itemName = itemShopJson.Sku_.Name.Replace(@"\u002F", @"\");
                }

                yield return new ScrapeItem
                (
                    itemName,
                    itemLink.AbsoluteUri,
                    itemId
                );
            }
        }

        private IEnumerable<T> Get<T>(MatchCollection matches) where T : new()
        {
            foreach (Match itemMatch in matches)
            {
                var content = itemMatch.Groups[1].Value.Replace(@"\""", @"""");
                yield return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions {  });
            }
        }

        private Dictionary<string, ItemShopJson> GetItemShopJsonDictionary(MatchCollection matches)
        {
            var itemShopCollection = Get<ItemShopJson>(matches);
            var result = new Dictionary<string, ItemShopJson>();

            foreach (var item in itemShopCollection)
            {
                if (item.Sku_ != null)
                {
                    result.Add(item.Sku_.SkuId, item);
                }
            }

            return result;
        }
    }
}