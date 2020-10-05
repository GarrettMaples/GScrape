using GScrape.Clients;
using MediatR;
using System.Collections.Generic;
using System.Text;

namespace GScrape.Requests.BestBuy
{
    public class BestBuyItemSearchRequest : IRequest<IAsyncEnumerable<BestBuyItemSearch>>
    {
    }

    public class BestBuyItemSearch
    {
        public string Name { get; set; }
        public string Html { get; set; }
    }

    internal class BestBuyItemSearchRequestHandler : RequestHandler<BestBuyItemSearchRequest, IAsyncEnumerable<BestBuyItemSearch>>
    {
        private readonly IBestBuyClient _bestBuyClient;

        public BestBuyItemSearchRequestHandler(IBestBuyClient bestBuyClient)
        {
            _bestBuyClient = bestBuyClient;
        }

        protected override async IAsyncEnumerable<BestBuyItemSearch> Handle(BestBuyItemSearchRequest request)
        {
            var html3090SearchPage = await _bestBuyClient.Get3090SearchPage();

            yield return new BestBuyItemSearch
            {
                Name = "Best Buy 3090 RTX",
                Html = html3090SearchPage
            };

            var html3080SearchPage = await _bestBuyClient.Get3080SearchPage();
            yield return new BestBuyItemSearch
            {
                Name = "Best Buy 3080 RTX",
                Html = html3080SearchPage
            };
        }
    }
}