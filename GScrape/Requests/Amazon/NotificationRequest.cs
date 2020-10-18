using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape.Requests.Amazon
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
            var scrapeRequest = new ScrapeRequest();
            var results = await _mediator.Send(scrapeRequest, cancellationToken);

            await foreach (var result in results.WithCancellation(cancellationToken))
            {
                return await _mediator.Send(result, cancellationToken);
            }

            return Unit.Value;
        }
    }
}