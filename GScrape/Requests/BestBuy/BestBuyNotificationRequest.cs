using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape.Requests.BestBuy
{
    public class BestBuyNotificationRequest : IRequest
    {
    }

    internal class BestBuyNotificationRequestHandler : IRequestHandler<BestBuyNotificationRequest>
    {
        private readonly IMediator _mediator;

        public BestBuyNotificationRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(BestBuyNotificationRequest notificationRequest, CancellationToken cancellationToken)
        {
            var bestBuyScrapeRequest = new BestBuyScrapeRequest();
            var results = await _mediator.Send(bestBuyScrapeRequest, cancellationToken);

            await foreach (var result in results.WithCancellation(cancellationToken))
            {
                return await _mediator.Send(result, cancellationToken);
            }

            return Unit.Value;
        }
    }
}