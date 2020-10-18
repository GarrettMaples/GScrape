using GScrape.Requests.BestBuy.Json;
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
    public class ScrapeRequest : IRequest<IAsyncEnumerable<ScrapeResult>>
    {
    }

    internal class ScrapeRequestHandler : RequestHandler<ScrapeRequest, IAsyncEnumerable<ScrapeResult>>
    {
        private static readonly Regex _itemFulfillmentRegex = new Regex(@"initializer.initializeComponent\({""creatorNamespace"":""fulfillment"".*?""({\\""app.+?}})"",",
            RegexOptions.Compiled | RegexOptions.IgnoreCase,
            TimeSpan.FromSeconds(10));

        private static readonly Regex _itemShopRegex = new Regex(
            @"initializer.initializeComponent\({""creatorNamespace"":""shop"".*?""contractVersion"":""v2"".*?""({\\""app.+?}})"",",
            RegexOptions.Compiled | RegexOptions.IgnoreCase,
            TimeSpan.FromSeconds(10));

        internal static readonly string BaseUrl = "https://www.bestbuy.com";

        private readonly IMediator _mediator;
        private readonly ILogger<ScrapeRequestHandler> _logger;
        private readonly HttpClient _httpClient;

        public ScrapeRequestHandler(IMediator mediator, ILogger<ScrapeRequestHandler> logger, HttpClient httpClient)
        {
            _mediator = mediator;
            _logger = logger;
            _httpClient = httpClient;
        }

        protected override async IAsyncEnumerable<ScrapeResult> Handle(ScrapeRequest request)
        {
            var searchRequest = new ItemSearchRequest();

            var searches = await _mediator.Send(searchRequest);

            await foreach (var search in searches)
            {
                var scrapeItems = GetItems(search.Html);

                yield return new ScrapeResult(search.Name, scrapeItems.ToAsyncEnumerable());
            }
        }

        private IEnumerable<ScrapeItem> GetItems(string htmlItemPage)
        {
            var itemFulfillmentPayload = Get<ItemFulfillmentPayload>(_itemFulfillmentRegex.Matches(htmlItemPage)).ToList();
            var itemShopJsonDictionary = GetItemShopJsonDictionary(_itemShopRegex.Matches(htmlItemPage));

            _logger.LogInformation($"{itemFulfillmentPayload.Count.ToString()} item matches found.");

            foreach (var item in itemFulfillmentPayload)
            {
                if (!item.ButtonState_.BSState.Contains("ADD_TO_CART", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var itemLink = new Uri(new Uri(BaseUrl), HttpUtility.UrlDecode(item.App_.SkuPdpUrl.Replace(@"\u002F", @"\")));

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
                yield return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions());
            }
        }

        private Dictionary<string, ItemShopPayload> GetItemShopJsonDictionary(MatchCollection matches)
        {
            var itemShopPayload = Get<ItemShopPayload>(matches);
            var result = new Dictionary<string, ItemShopPayload>();

            foreach (var item in itemShopPayload)
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