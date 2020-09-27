using GScrape.Clients;
using MediatR;
using System.Collections.Generic;

namespace GScrape.Requests.Newegg
{
    public class NeweggItemSearchRequest : IRequest<IAsyncEnumerable<NeweggItemSearch>>
    {
    }

    public class NeweggItemSearch
    {
        public string Name { get; set; }
        public string Html { get; set; }
    }

    internal class NeweggItemSearchRequestHandler : RequestHandler<NeweggItemSearchRequest, IAsyncEnumerable<NeweggItemSearch>>
    {
        private readonly INeweggClient _neweggClient;

        public NeweggItemSearchRequestHandler(INeweggClient neweggClient)
        {
            _neweggClient = neweggClient;
        }

        protected override async IAsyncEnumerable<NeweggItemSearch> Handle(NeweggItemSearchRequest request)
        {
            var html3090SearchPage = await _neweggClient.Get3090SearchPage();
            yield return new NeweggItemSearch
            {
                Name = "3090 RTX",
                Html = html3090SearchPage
            };
        }
    }
}