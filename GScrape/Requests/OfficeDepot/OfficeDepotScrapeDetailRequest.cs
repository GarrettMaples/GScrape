using GScrape.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace GScrape.Requests.OfficeDepot
{
    public class OfficeDepotScrapeDetailRequest : IRequest<ScrapeResult>
    {
        public OfficeDepotScrapeDetailRequest(string name, string html)
        {
            Name = name;
            Html = html;
        }

        public string Name { get; }
        public string Html { get; }
    }

    internal class OfficeDepotScrapeDetailRequestHandler : IRequestHandler<OfficeDepotScrapeDetailRequest, ScrapeResult>
    {
        private static readonly Regex _itemInfoJsonRegex = new Regex(
            @"<script[^>]+?type=""text\/javascript""[^>]*?>[^>]*?window\.dataLayer\.push\(({""event"":""onPageRendered"".+?)\);\s+?<\/script>",
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline,
            TimeSpan.FromSeconds(10));

        public static readonly string OfficeDepotBaseUrl = "https://www.officedepot.com";
        public static readonly string PartialItemUrl = "/a/products/";

        public async Task<ScrapeResult> Handle(OfficeDepotScrapeDetailRequest request, CancellationToken cancellationToken)
        {
            var itemInfoJson = GetItemInfoDetailJson(request.Html);

            var scrapeItems = GetItems(itemInfoJson);

            return new ScrapeResult(request.Name, scrapeItems.ToAsyncEnumerable());
        }

        private IEnumerable<ScrapeItem> GetItems(ItemInfoDetailJson itemInfoJson)
        {
            if (!itemInfoJson.Product.IsOutOfStock)
            {
                yield return new ScrapeItem
                (
                    HttpUtility.HtmlDecode(itemInfoJson.Product.Name),
                    new Uri(new Uri(OfficeDepotBaseUrl), $"{PartialItemUrl}{itemInfoJson.Product.Sku}").AbsoluteUri,
                    itemInfoJson.Product.Sku
                );
            }
        }

        private ItemInfoDetailJson GetItemInfoDetailJson(string html)
        {
            var itemInfoJsonMatch = _itemInfoJsonRegex.Match(html);

            return !itemInfoJsonMatch.Success ? null : JsonSerializer.Deserialize<ItemInfoDetailJson>(itemInfoJsonMatch.Groups[1].Value);
        }
    }
}