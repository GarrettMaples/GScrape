using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape.Requests.OfficeDepot
{
    public class OfficeDepotRequest : IRequest
    {
        
    }
    
    internal class OfficeDepotRequestHandler : IRequestHandler<OfficeDepotRequest>
    {
        private readonly IMediator _mediator;

        public OfficeDepotRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(OfficeDepotRequest request, CancellationToken cancellationToken)
        {
            var officeDepotScrapeRequest = new OfficeDepotScrapeRequest();
            var results = await _mediator.Send(officeDepotScrapeRequest, cancellationToken);
            
            await foreach (var result in results.WithCancellation(cancellationToken))
            {
                return await _mediator.Send(result, cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}