using GScrape.Clients;
using MediatR;
using System;
using System.Collections.Generic;

namespace GScrape.Requests.OfficeDepot
{
    public class OfficeDepotItemSearchRequest : IRequest<IAsyncEnumerable<OfficeDepotItemSearch>>
    {
    }

    public class OfficeDepotItemSearch
    {
        public string Name { get; set; }
        public string Html { get; set; }
        public bool IsDetailsPage { get; set; }
    }

    internal class OfficeDepotItemSearchRequestHandler : RequestHandler<OfficeDepotItemSearchRequest, IAsyncEnumerable<OfficeDepotItemSearch>>
    {
        private readonly IOfficeDepotClient _officeDepotClient;

        public OfficeDepotItemSearchRequestHandler(IOfficeDepotClient officeDepotClient)
        {
            _officeDepotClient = officeDepotClient;
        }

        protected override async IAsyncEnumerable<OfficeDepotItemSearch> Handle(OfficeDepotItemSearchRequest request)
        {
            var responseMessage = await _officeDepotClient.Get3090SearchPage();

            var responseUri = responseMessage.RequestMessage.RequestUri.ToString();
            var html = await responseMessage.Content.ReadAsStringAsync();

            yield return new OfficeDepotItemSearch
            {
                Name = "Office Depot 3090 RTX",
                Html = html,
                IsDetailsPage = !responseUri.Contains("search", StringComparison.OrdinalIgnoreCase)
            };
        }
    }
}