using GScrape.Clients;
using MediatR;
using System.Collections.Generic;

namespace GScrape.Requests.Walmart
{
    public class ItemSearchRequest : IRequest<IAsyncEnumerable<ItemSearch>>
    {
    }

    internal class ItemSearchRequestHandler : RequestHandler<ItemSearchRequest, IAsyncEnumerable<ItemSearch>>
    {
        private readonly IWalmartClient _client;

        public ItemSearchRequestHandler(IWalmartClient client)
        {
            _client = client;
        }

        protected override async IAsyncEnumerable<ItemSearch> Handle(ItemSearchRequest request)
        {
            yield return new ItemSearch
            {
                Name = "Walmart Honeywell HEPA Filter",
                Html = await _client.GetHoneywellHepaFilter()
            };
        }
    }
}