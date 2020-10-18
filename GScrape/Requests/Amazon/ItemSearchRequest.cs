using GScrape.Clients;
using MediatR;
using System.Collections.Generic;

namespace GScrape.Requests.Amazon
{
    public class ItemSearchRequest : IRequest<IAsyncEnumerable<ItemSearch>>
    {
    }

    public class ItemSearch
    {
        public string Name { get; set; }
        public string Html { get; set; }
    }

    internal class ItemSearchRequestHandler : RequestHandler<ItemSearchRequest, IAsyncEnumerable<ItemSearch>>
    {
        private readonly IAmazonClient _client;

        public ItemSearchRequestHandler(IAmazonClient client)
        {
            _client = client;
        }

        protected override async IAsyncEnumerable<ItemSearch> Handle(ItemSearchRequest request)
        {
            var html3090SearchPage = await _client.Get3090Page();
            yield return new ItemSearch
            {
                Name = "3090 RTX",
                Html = html3090SearchPage
            };
            
            var html3080SearchPage = await _client.Get3080Page();
            yield return new ItemSearch
            {
                Name = "3080 RTX",
                Html = html3080SearchPage
            };
        }
    }
}