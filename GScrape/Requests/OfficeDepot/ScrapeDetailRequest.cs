using GScrape.Requests.OfficeDepot.Json;
using GScrape.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;

namespace GScrape.Requests.OfficeDepot
{
    public class ScrapeDetailRequest : IRequest<ScrapeResult>
    {
        public ScrapeDetailRequest(string name, string html)
        {
            Name = name;
            Html = html;
        }

        public string Name { get; }
        public string Html { get; }
    }

    internal class ScrapeDetailRequestHandler : RequestHandler<ScrapeDetailRequest, ScrapeResult>
    {
        private const string OfficeDepotBaseUrl = "https://www.officedepot.com";
        private const string PartialItemUrl = "/a/products/";

        private static readonly Regex _itemInfoJsonRegex = new Regex(
            @"<script[^>]+?type=""text\/javascript""[^>]*?>[^>]*?window\.dataLayer\.push\(({""event"":""onPageRendered"".+?)\);\s+?<\/script>",
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline,
            TimeSpan.FromSeconds(10));

        protected override ScrapeResult Handle(ScrapeDetailRequest request)
        {
            var itemInfoJson = GetItemInfoDetailJson(request.Html);

            var scrapeItems = GetItems(itemInfoJson);

            return new ScrapeResult(request.Name, scrapeItems.ToAsyncEnumerable());
        }

        private IEnumerable<ScrapeItem> GetItems(ItemInfoDetailPayload itemInfoPayload)
        {
            if (!itemInfoPayload.Product.IsOutOfStock)
            {
                yield return new ScrapeItem
                (
                    HttpUtility.HtmlDecode(itemInfoPayload.Product.Name),
                    new Uri(new Uri(OfficeDepotBaseUrl), $"{PartialItemUrl}{itemInfoPayload.Product.Sku}").AbsoluteUri,
                    itemInfoPayload.Product.Sku
                );
            }
        }

        private ItemInfoDetailPayload GetItemInfoDetailJson(string html)
        {
            var itemInfoJsonMatch = _itemInfoJsonRegex.Match(html);

            return !itemInfoJsonMatch.Success ? null : JsonSerializer.Deserialize<ItemInfoDetailPayload>(itemInfoJsonMatch.Groups[1].Value);
        }
    }
}