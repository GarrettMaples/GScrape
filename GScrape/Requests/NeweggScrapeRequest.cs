using GScrape.Clients;
using GScrape.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape.Requests
{
    public class NeweggScrapeRequest : IRequest<NeweggScrapeResult>
    {
    }

    internal class NeweggScrapeRequestHandler : IRequestHandler<NeweggScrapeRequest, NeweggScrapeResult>
    {
        private static readonly Regex _itemContainerRegex = new Regex(@"<div class=""item-container"">(.*?)<\/div><\/div><\/div>", RegexOptions.Compiled | RegexOptions.IgnoreCase,
            TimeSpan.FromSeconds(10));

        private static readonly Regex _itemPromoRegex = new Regex(@"<p class=""item-promo"">(.*?)<\/p>", RegexOptions.Compiled | RegexOptions.IgnoreCase, TimeSpan.FromSeconds(10));

        private static readonly Regex _itemInfoRegex =
            new Regex(@"<div class=""item-branding"">.*?<\/a><\/div><a href=""(?<link>[^""]*)"".*?>(?<name>.*?)<\/a>", RegexOptions.Compiled | RegexOptions.IgnoreCase,
                TimeSpan.FromSeconds(10));

        private readonly INeweggClient _neweggClient;
        private readonly ILogger<NeweggScrapeRequestHandler> _logger;

        public NeweggScrapeRequestHandler(INeweggClient neweggClient, ILogger<NeweggScrapeRequestHandler> logger)
        {
            _neweggClient = neweggClient;
            _logger = logger;
        }

        public async Task<NeweggScrapeResult> Handle(NeweggScrapeRequest request, CancellationToken cancellationToken)
        {
            var htmlItemPage = await _neweggClient.Get3090SearchPage();

            var itemMatches = _itemContainerRegex.Matches(htmlItemPage);

            _logger.LogInformation($"{itemMatches.Count} item matches found.");

            var results = new List<(string itemName, string itemLink)>();

            foreach (Match itemMatch in itemMatches)
            {
                var itemPromoMatch = _itemPromoRegex.Match(itemMatch.Value);

                if (itemPromoMatch.Success && itemPromoMatch.Value.Contains("OUT OF STOCK", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var infoMatch = _itemInfoRegex.Match(itemMatch.Value);

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

            return new NeweggScrapeResult
            {
                Results = results
            };
        }
    }
}