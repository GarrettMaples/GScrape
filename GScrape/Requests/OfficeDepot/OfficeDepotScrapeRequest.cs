using GScrape.Results;
using MediatR;
using System.Collections.Generic;

namespace GScrape.Requests.OfficeDepot
{
    public class OfficeDepotScrapeRequest : IRequest<IAsyncEnumerable<ScrapeResult>>
    {
    }

    internal class OfficeDepotScrapeRequestHandler : RequestHandler<OfficeDepotScrapeRequest, IAsyncEnumerable<ScrapeResult>>
    {
        private readonly IMediator _mediator;

        public OfficeDepotScrapeRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override async IAsyncEnumerable<ScrapeResult> Handle(OfficeDepotScrapeRequest request)
        {
            var req = new OfficeDepotItemSearchRequest();

            var searches = await _mediator.Send(req);

            await foreach (var search in searches)
            {
                if (search.IsDetailsPage)
                {
                    var detailsRequest = new OfficeDepotScrapeDetailRequest(search.Name, search.Html);
                    yield return await _mediator.Send(detailsRequest);
                }
                else
                {
                    var searchRequest = new OfficeDepotScrapeSearchRequest(search.Name, search.Html);
                    yield return await _mediator.Send(searchRequest);
                }
            }
        }
    }
}