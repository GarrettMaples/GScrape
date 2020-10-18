using GScrape.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GScrape.Requests
{
    public class NotificationRequest : IRequest
    {
        public NotificationRequest(Func<IRequest<IAsyncEnumerable<ScrapeResult>>> scrapeRequestFactory)
        {
            ScrapeRequestFactory = scrapeRequestFactory;
        }

        public Func<IRequest<IAsyncEnumerable<ScrapeResult>>> ScrapeRequestFactory { get; }
    }

    internal class NotificationRequestHandler : IRequestHandler<NotificationRequest>
    {
        private readonly IMediator _mediator;

        public NotificationRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(NotificationRequest request, CancellationToken cancellationToken)
        {
            var results = await _mediator.Send(request.ScrapeRequestFactory(), cancellationToken);

            await foreach (var result in results.WithCancellation(cancellationToken))
            {
                return await _mediator.Send(result, cancellationToken);
            }

            return Unit.Value;
        }
    }
}