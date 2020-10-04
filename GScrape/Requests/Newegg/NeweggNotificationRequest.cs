using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape.Requests.Newegg
{
    public class NeweggNotificationRequest : IRequest
    {
    }

    internal class NeweggNotificationRequestHandler : IRequestHandler<NeweggNotificationRequest>
    {
        private readonly IMediator _mediator;

        public NeweggNotificationRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(NeweggNotificationRequest notificationRequest, CancellationToken cancellationToken)
        {
            var neweggScrapeRequest = new NeweggScrapeRequest();
            var results = await _mediator.Send(neweggScrapeRequest, cancellationToken);

            await foreach (var result in results.WithCancellation(cancellationToken))
            {
                return await _mediator.Send(result, cancellationToken);
            }

            return Unit.Value;
        }
    }
}