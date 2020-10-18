using GScrape.Results;
using MediatR;
using System.Collections.Generic;

namespace GScrape.Requests.OfficeDepot
{
    public class ScrapeRequest : IRequest<IAsyncEnumerable<ScrapeResult>>
    {
    }

    internal class ScrapeRequestHandler : RequestHandler<ScrapeRequest, IAsyncEnumerable<ScrapeResult>>
    {
        private readonly IMediator _mediator;

        public ScrapeRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override async IAsyncEnumerable<ScrapeResult> Handle(ScrapeRequest request)
        {
            var req = new ItemSearchRequest();

            var searches = await _mediator.Send(req);

            await foreach (var search in searches)
            {
                if (search.IsDetailsPage)
                {
                    var detailsRequest = new ScrapeDetailRequest(search.Name, search.Html);
                    yield return await _mediator.Send(detailsRequest);
                }
                else
                {
                    var searchRequest = new ScrapeSearchRequest(search.Name, search.Html);
                    yield return await _mediator.Send(searchRequest);
                }
            }
        }
    }
}