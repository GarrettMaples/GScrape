using GScrape.Clients;
using GScrape.Requests.OfficeDepot.Json;
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
    public class ScrapeSearchRequest : IRequest<ScrapeResult>
    {
        public ScrapeSearchRequest(string name, string html)
        {
            Name = name;
            Html = html;
        }

        public string Name { get; }
        public string Html { get; }
    }

    internal class ScrapeSearchRequestHandler : IRequestHandler<ScrapeSearchRequest, ScrapeResult>
    {
        private static readonly Regex _skuRegex = new Regex(
            @"<input[^>]+?type=""hidden""[^>]+?id=""hiddenSkuId\d+?""[^>]+?value=""(\d*?)""[^>]*?>",
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline,
            TimeSpan.FromSeconds(10));

        internal static readonly string BaseUrl = "https://www.officedepot.com";

        private readonly IOfficeDepotClient _officeDepotClient;

        public ScrapeSearchRequestHandler(IOfficeDepotClient officeDepotClient)
        {
            _officeDepotClient = officeDepotClient;
        }

        public async Task<ScrapeResult> Handle(ScrapeSearchRequest request, CancellationToken cancellationToken)
        {
            var itemInfoJson = await GetItemInfoJson(request.Html);

            var scrapeItems = GetItems(itemInfoJson);

            return new ScrapeResult(request.Name, scrapeItems.ToAsyncEnumerable());
        }

        private IEnumerable<ScrapeItem> GetItems(ItemInfoPayload itemInfoPayload)
        {
            foreach (var item in itemInfoPayload.SkuPriceList.Values)
            {
                if (item.AvailableQty > 0)
                {
                    yield return new ScrapeItem(item.ShortDescription, new Uri(new Uri(BaseUrl), item.SkuUrl).AbsoluteUri, item.SkuId);
                }
            }
        }

        private async Task<ItemInfoPayload> GetItemInfoJson(string html)
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