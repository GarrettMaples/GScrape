using GScrape.Clients;
using GScrape.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GScrape.Requests.OfficeDepot
{
    public class OfficeDepotScrapeRequest : IRequest<IAsyncEnumerable<ScrapeResult>>
    {
    }

    internal class OfficeDepotScrapeRequestHandler : RequestHandler<OfficeDepotScrapeRequest, IAsyncEnumerable<ScrapeResult>>
    {
        private static readonly Regex _skuRegex = new Regex(
            @"<input[^>]+?type=""hidden""[^>]+?id=""hiddenSkuId\d+?""[^>]+?value=""(\d*?)""[^>]*?>",
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline,
            TimeSpan.FromSeconds(10));

        public static readonly string OfficeDepotBaseUrl = "https://www.officedepot.com";

        private readonly IMediator _mediator;
        private readonly ILogger<OfficeDepotScrapeRequestHandler> _logger;
        private readonly IOfficeDepotClient _officeDepotClient;

        public OfficeDepotScrapeRequestHandler(IMediator mediator, ILogger<OfficeDepotScrapeRequestHandler> logger, IOfficeDepotClient officeDepotClient)
        {
            _mediator = mediator;
            _logger = logger;
            _officeDepotClient = officeDepotClient;
        }
        
        protected override async IAsyncEnumerable<ScrapeResult> Handle(OfficeDepotScrapeRequest request)
        {
            var searchRequest = new OfficeDepotItemSearchRequest();

            var searches = await _mediator.Send(searchRequest);

            await foreach (var search in searches)
            {
                var itemInfoJson = await GetItemInfoJson(search.Html);
                
                var instockItems = new List<(string itemName, string itemLink)>();

                foreach (var item in itemInfoJson.SkuPriceList.Values)
                {
                    if (item.AvailableQty > 0)
                    {
                        instockItems.Add((item.ShortDescription, new Uri(new Uri(OfficeDepotBaseUrl), item.SkuUrl).AbsoluteUri));
                    }
                }

                yield return new ScrapeResult
                {
                    Results = new KeyValuePair<string, IEnumerable<(string itemName, string itemLink)>>(search.Name, instockItems)
                };
            }
        }

        private async Task<ItemInfoJson> GetItemInfoJson(string html)
        {
            var skuMatches = _skuRegex.Matches(html);

            if (!skuMatches.Any())
            {
                return null;
            }

            var skus = string.Join(",", skuMatches.Select(x => x.Groups[1].Value));

            return await _officeDepotClient.GetItemInfoJson(skus);
        }
    }
}