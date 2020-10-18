using GScrape.Clients;
using MediatR;
using System.Collections.Generic;

namespace GScrape.Requests.BestBuy
{
    public class ItemSearchRequest : IRequest<IAsyncEnumerable<ItemSearch>>
    {
    }

    internal class ItemSearchRequestHandler : RequestHandler<ItemSearchRequest, IAsyncEnumerable<ItemSearch>>
    {
        private readonly IBestBuyClient _bestBuyClient;

        public ItemSearchRequestHandler(IBestBuyClient bestBuyClient)
        {
            _bestBuyClient = bestBuyClient;
        }

        protected override async IAsyncEnumerable<ItemSearch> Handle(ItemSearchRequest request)
        {
            var html3090SearchPage = await _bestBuyClient.Get3090SearchPage();

            yield return new ItemSearch
            {
                Name = "Best Buy 3090 RTX",
                Html = html3090SearchPage
            };

            var html3080SearchPage = await _bestBuyClient.Get3080SearchPage();
            yield return new ItemSearch
            {
                Name = "Best Buy 3080 RTX",
                Html = html3080SearchPage
            };
        }
    }
}