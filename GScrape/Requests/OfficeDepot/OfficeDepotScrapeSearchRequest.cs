using GScrape.Clients;
using GScrape.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape.Requests.OfficeDepot
{
    public class OfficeDepotScrapeSearchRequest : IRequest<ScrapeResult>
    {
        public OfficeDepotScrapeSearchRequest(string name, string html)
        {
            Name = name;
            Html = html;
        }

        public string Name { get; }
        public string Html { get; }
    }

    internal class OfficeDepotScrapeSearchRequestHandler : IRequestHandler<OfficeDepotScrapeSearchRequest, ScrapeResult>
    {
        private static readonly Regex _skuRegex = new Regex(
            @"<input[^>]+?type=""hidden""[^>]+?id=""hiddenSkuId\d+?""[^>]+?value=""(\d*?)""[^>]*?>",
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline,
            TimeSpan.FromSeconds(10));

        public static readonly string OfficeDepotBaseUrl = "https://www.officedepot.com";
        public static readonly string PartialItemUrl = "/a/products/";

        private readonly IOfficeDepotClient _officeDepotClient;

        public OfficeDepotScrapeSearchRequestHandler(IOfficeDepotClient officeDepotClient)
        {
            _officeDepotClient = officeDepotClient;
        }

        public async Task<ScrapeResult> Handle(OfficeDepotScrapeSearchRequest request, CancellationToken cancellationToken)
        {
            var itemInfoJson = await GetItemInfoJson(request.Html);

            var scrapeItems = GetItems(itemInfoJson);

            return new ScrapeResult(request.Name, scrapeItems);
        }

        private async IAsyncEnumerable<ScrapeItem> GetItems(ItemInfoJson itemInfoJson)
        {
            foreach (var item in itemInfoJson.SkuPriceList.Values)
            {
                if (item.AvailableQty > 0)
                {
                    yield return new ScrapeItem(item.ShortDescription, new Uri(new Uri(OfficeDepotBaseUrl), item.SkuUrl).AbsoluteUri, item.SkuId);
                }
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