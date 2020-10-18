using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape.Requests.Newegg
{
    public class NotificationRequest : IRequest
    {
    }

    internal class NotificationRequestHandler : IRequestHandler<NotificationRequest>
    {
        private readonly IMediator _mediator;

        public NotificationRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(NotificationRequest notificationRequest, CancellationToken cancellationToken)
        {
            var neweggScrapeRequest = new ScrapeRequest();
            var results = await _mediator.Send(neweggScrapeRequest, cancellationToken);

            await foreach (var result in results.WithCancellation(cancellationToken))
            {
                return await _mediator.Send(result, cancellationToken);
            }

            return Unit.Value;
        }
    }
}