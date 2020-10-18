using GScrape.Results;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape.Requests
{
    public class NotificationRequest<T> : IRequest where T : class, IRequest<IAsyncEnumerable<ScrapeResult>>, new()
    {
    }

    internal class NotificationRequestHandler<T> : IRequestHandler<NotificationRequest<T>> where T : class, IRequest<IAsyncEnumerable<ScrapeResult>>, new()
    {
        private readonly IMediator _mediator;

        public NotificationRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(NotificationRequest<T> request, CancellationToken cancellationToken)
        {
            var scrapeRequest = new T();
            var results = await _mediator.Send(scrapeRequest, cancellationToken);

            await foreach (var result in results.WithCancellation(cancellationToken))
            {
                return await _mediator.Send(result, cancellationToken);
            }

            return Unit.Value;
        }
    }
}