using GScrape.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace GScrape.Requests.Newegg
{
    public class ScrapeRequest : IRequest<IAsyncEnumerable<ScrapeResult<ScrapeItem>>>
    {
    }

    internal class ScrapeRequestHandler : RequestHandler<ScrapeRequest, IAsyncEnumerable<ScrapeResult<ScrapeItem>>>
    {
        private static readonly Regex _itemContainerRegex = new Regex(@"<div class=""item-container"">(.*?)<\/div><\/div><\/div>", RegexOptions.Compiled | RegexOptions.IgnoreCase,
            TimeSpan.FromSeconds(10));

        private static readonly Regex _itemPromoRegex = new Regex(@"<p class=""item-promo"">(.*?)<\/p>", RegexOptions.Compiled | RegexOptions.IgnoreCase, TimeSpan.FromSeconds(10));

        private static readonly Regex _itemInfoRegex =
            new Regex(@"<div class=""item-branding"">.*?<\/a><\/div><a href=""(?<link>[^""]*)"".*?>(?<name>.*?)<\/a>", RegexOptions.Compiled | RegexOptions.IgnoreCase,
                TimeSpan.FromSeconds(10));

        private static readonly Regex _addToCartButtonRegex =
            new Regex(@"<div[^>]+?id=""ProductBuy""[^>]+?class=""product-buy""[^>]*?>.*?<button.*?Add to cart.*?<\/div><\/div><\/div>",
                RegexOptions.Compiled | RegexOptions.IgnoreCase, TimeSpan.FromSeconds(10));

        private static readonly Regex _itemIdRegex = new Regex("Item=(.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5));

        private readonly IMediator _mediator;
        private readonly ILogger<ScrapeRequestHandler> _logger;
        private readonly HttpClient _httpClient;

        public ScrapeRequestHandler(IMediator mediator, ILogger<ScrapeRequestHandler> logger, HttpClient httpClient)
        {
            _mediator = mediator;
            _logger = logger;
            _httpClient = httpClient;
        }

        protected override async IAsyncEnumerable<ScrapeResult<ScrapeItem>> Handle(ScrapeRequest request)
        {
            var searchRequest = new ItemSearchRequest();

            var searches = await _mediator.Send(searchRequest);

            await foreach (var search in searches)
            {
                var scrapeItems = GetItems(search.Html);

                yield return new ScrapeResult<ScrapeItem>(search.Name, scrapeItems);
            }
        }

        private async IAsyncEnumerable<ScrapeItem> GetItems(string htmlItemPage)
        {
            var itemMatches = _itemContainerRegex.Matches(htmlItemPage);

            _logger.LogInformation($"{itemMatches.Count.ToString()} item matches found.");

            foreach (Match itemMatch in itemMatches)
            {
                var item = itemMatch.Groups[1].Value;
                var itemPromoMatch = _itemPromoRegex.Match(item);

                if (itemPromoMatch.Success && itemPromoMatch.Groups[1].Value.Contains("OUT OF STOCK", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var infoMatch = _itemInfoRegex.Match(item);

                if (infoMatch.Success)
                {
                    var link = infoMatch.Groups["link"].Value;
                    var name = infoMatch.Groups["name"].Value;

                    var itemIdMatch = _itemIdRegex.Match(link);

                    if (!itemIdMatch.Success)
                    {
                        _logger.LogError($"Unable to match on item id in URL. URL: {link}");
                        continue;
                    }

                    var itemId = itemIdMatch.Groups[1].Value;

                    var detailHtml = await _httpClient.GetStringAsync(link);

                    if (!_addToCartButtonRegex.IsMatch(detailHtml))
                    {
                        continue;
                    }

                    yield return new ScrapeItem
                    (
                        name,
                        link,
                        itemId
                    );
                }
                else
                {
                    _logger.LogError($"Unable to match on item details. HTML: {item}");
                }
            }
        }
    }
}