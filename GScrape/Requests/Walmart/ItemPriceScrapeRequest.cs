using GScrape.Requests.Walmart.Json;
using GScrape.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace GScrape.Requests.Walmart
{
    public class ItemPriceScrapeRequest : IRequest<IAsyncEnumerable<ScrapeResult<ItemPriceScrapeItem>>>
    {
    }

    internal class ItemPriceScrapeRequestHandler : RequestHandler<ItemPriceScrapeRequest, IAsyncEnumerable<ScrapeResult<ItemPriceScrapeItem>>>
    {
        private static readonly Regex _itemPayloadRegex =
            new Regex(@"<script[^>]+?id=""item""[^>]+?type=""application\/json"">(.+?)<\/script>", RegexOptions.Compiled | RegexOptions.IgnoreCase, TimeSpan.FromSeconds(15));

        internal static readonly string BaseUrl = "https://www.walmart.com";

        private readonly IMediator _mediator;
        private readonly ILogger<ItemPriceScrapeRequestHandler> _logger;

        public ItemPriceScrapeRequestHandler(IMediator mediator, ILogger<ItemPriceScrapeRequestHandler> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        protected override async IAsyncEnumerable<ScrapeResult<ItemPriceScrapeItem>> Handle(ItemPriceScrapeRequest request)
        {
            var itemSearchRequest = new ItemSearchRequest();
            var itemSearches = await _mediator.Send(itemSearchRequest);

            await foreach (var itemSearch in itemSearches)
            {
                var itemPayloadMatch = _itemPayloadRegex.Match(itemSearch.Html);

                if (!itemPayloadMatch.Success)
                {
                    throw new InvalidOperationException($"Unable to find item payload match for {itemSearch.Name}. HTML: {itemSearch.Html}");
                }
                
                var itemPayload = JsonSerializer.Deserialize<ItemPayload>(itemPayloadMatch.Groups[1].Value);
                var scrapeItems = ScrapeItems(itemPayload);

                yield return new ScrapeResult<ItemPriceScrapeItem>(itemSearch.Name, scrapeItems.ToAsyncEnumerable());
            }
        }

        private IEnumerable<ItemPriceScrapeItem> ScrapeItems(ItemPayload itemPayload)
        {
            _logger.LogInformation($"{itemPayload.Item.Product.BuyBox.Products.Length.ToString()} Walmart item found.");

            foreach (var product in itemPayload.Item.Product.BuyBox.Products)
            {
                var itemLink = new Uri(new Uri(BaseUrl), product.CanonicalUrl).AbsoluteUri;
                var itemId = $"{product.UsItemId}";
                yield return new ItemPriceScrapeItem(product.ProductName, itemLink, itemId, product.PriceMap.Price);
            }
        }
    }
}