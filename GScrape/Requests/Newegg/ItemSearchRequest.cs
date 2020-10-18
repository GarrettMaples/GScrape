using GScrape.Clients;
using MediatR;
using System.Collections.Generic;

namespace GScrape.Requests.Newegg
{
    public class ItemSearchRequest : IRequest<IAsyncEnumerable<ItemSearch>>
    {
    }

    internal class ItemSearchRequestHandler : RequestHandler<ItemSearchRequest, IAsyncEnumerable<ItemSearch>>
    {
        private readonly INeweggClient _neweggClient;

        public ItemSearchRequestHandler(INeweggClient neweggClient)
        {
            _neweggClient = neweggClient;
        }

        protected override async IAsyncEnumerable<ItemSearch> Handle(ItemSearchRequest request)
        {
            var html3090SearchPage = await _neweggClient.Get3090SearchPage();
            yield return new ItemSearch
            {
                Name = "Newegg 3090 RTX",
                Html = html3090SearchPage
            };

            var html3080SearchPage = await _neweggClient.Get3080SearchPage();
            yield return new ItemSearch
            {
                Name = "Newegg 3080 RTX",
                Html = html3080SearchPage
            };
        }
    }
}