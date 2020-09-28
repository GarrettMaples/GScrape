using GScrape.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GScrape.Requests.Newegg
{
    public class NeweggScrapeRequest : IRequest<IAsyncEnumerable<ScrapeResult>>
    {
    }

    internal class NeweggScrapeRequestHandler : RequestHandler<NeweggScrapeRequest, IAsyncEnumerable<ScrapeResult>>
    {
        private static readonly Regex _itemContainerRegex = new Regex(@"<div class=""item-container"">(.*?)<\/div><\/div><\/div>", RegexOptions.Compiled | RegexOptions.IgnoreCase,
            TimeSpan.FromSeconds(10));

        private static readonly Regex _itemPromoRegex = new Regex(@"<p class=""item-promo"">(.*?)<\/p>", RegexOptions.Compiled | RegexOptions.IgnoreCase, TimeSpan.FromSeconds(10));

        private static readonly Regex _itemInfoRegex =
            new Regex(@"<div class=""item-branding"">.*?<\/a><\/div><a href=""(?<link>[^""]*)"".*?>(?<name>.*?)<\/a>", RegexOptions.Compiled | RegexOptions.IgnoreCase,
                TimeSpan.FromSeconds(10));

        private readonly IMediator _mediator;
        private readonly ILogger<NeweggScrapeRequestHandler> _logger;

        public NeweggScrapeRequestHandler(IMediator mediator, ILogger<NeweggScrapeRequestHandler> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        protected override async IAsyncEnumerable<ScrapeResult> Handle(NeweggScrapeRequest request)
        {
            var searchRequest = new NeweggItemSearchRequest();

            var searches = await _mediator.Send(searchRequest);

            await foreach (var search in searches)
            {
                var results = ProcessRequest(search.Html);

                yield return new ScrapeResult
                {
                    Results = new KeyValuePair<string, IEnumerable<(string itemName, string itemLink)>>(search.Name, results)
                };
            }
        }

        private IEnumerable<(string itemName, string itemLink)> ProcessRequest(string htmlItemPage)
        {
            var itemMatches = _itemContainerRegex.Matches(htmlItemPage);

            _logger.LogInformation($"{itemMatches.Count} item matches found.");

            var results = new List<(string itemName, string itemLink)>();

            foreach (Match itemMatch in itemMatches)
            {
                var itemPromoMatch = _itemPromoRegex.Match(itemMatch.Groups[1].Value);

                if (itemPromoMatch.Success && itemPromoMatch.Groups[1].Value.Contains("OUT OF STOCK", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var infoMatch = _itemInfoRegex.Match(itemMatch.Groups[1].Value);

                if (infoMatch.Success)
                {
                    var link = infoMatch.Groups["link"].Value;
                    var name = infoMatch.Groups["name"].Value;

                    results.Add((itemName: name, itemLink: link));
                }
                else
                {
                    results.Add((itemName: "Unknown", itemLink: "Unknown"));
                }
            }

            return results;
        }
    }
}