using GScrape.Requests.Amazon.Json;
using GScrape.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace GScrape.Requests.Amazon
{
    public class ScrapeRequest : IRequest<IAsyncEnumerable<ScrapeResult>>
    {
    }

    internal class ScrapeRequestHandler : RequestHandler<ScrapeRequest, IAsyncEnumerable<ScrapeResult>>
    {
        private static readonly Regex _productPayloadRegex =
            new Regex(@"var\s+?config\s+?=(\s*?{.+?});", RegexOptions.Compiled | RegexOptions.IgnoreCase, TimeSpan.FromSeconds(15));

        internal static readonly string BaseUrl = "https://www.amazon.com";

        private readonly IMediator _mediator;
        private readonly ILogger<ScrapeRequestHandler> _logger;

        public ScrapeRequestHandler(IMediator mediator, ILogger<ScrapeRequestHandler> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        protected override async IAsyncEnumerable<ScrapeResult> Handle(ScrapeRequest request)
        {
            var itemSearchRequest = new ItemSearchRequest();
            var itemSearches = await _mediator.Send(itemSearchRequest);

            await foreach (var itemSearch in itemSearches)
            {
                var payloadJsonMatches = _productPayloadRegex.Matches(itemSearch.Html);

                if (payloadJsonMatches.Count < 2)
                {
                    throw new InvalidOperationException($"Unable to find product payload JSON. HTML: {itemSearch.Html}");
                }

                var payload = JsonSerializer.Deserialize<Payload>(payloadJsonMatches[1].Groups[1].Value);
                var scrapeItems = ScrapeItems(payload);

                yield return new ScrapeResult(itemSearch.Name, scrapeItems.ToAsyncEnumerable());
            }
        }

        private IEnumerable<ScrapeItem> ScrapeItems(Payload payload)
        {
            _logger.LogInformation($"{payload.Content.Products.Count.ToString()} Amazon items found.");
            foreach (var product in payload.Content.Products)
            {
                foreach (var buyingOption in product.BuyingOptions)
                {
                    if (!buyingOption.Availability.Type.Contains("IN_STOCK", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    var itemLink = new Uri(new Uri(BaseUrl), product.Links.ViewOnAmazon.Url).AbsoluteUri;
                    var itemId = product.Asin;
                    yield return new ScrapeItem(product.Title.DisplayString, itemLink, itemId);
                }
            }
        }
    }
}