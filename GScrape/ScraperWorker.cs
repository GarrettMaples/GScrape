using GScrape.Requests;
using MediatR;
using System.Threading.Tasks;

namespace GScrape
{
    public interface IScraperWorker
    {
        Task DoWork();
    }

    internal class ScraperWorker : IScraperWorker
    {
        private readonly IMediator _mediator;

        public ScraperWorker(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task DoWork()
        {
            // var request = new NotificationRequest();
            // await _mediator.Send(request);

            // var officeDepotRequest = new NotificationRequest();
            // await _mediator.Send(officeDepotRequest);

            // var bestBuyRequest = new NotificationRequest();
            // await _mediator.Send(bestBuyRequest);

            var amazonNotificationRequest = new NotificationRequest<Requests.Amazon.ScrapeRequest>();
            await _mediator.Send(amazonNotificationRequest);
        }
    }
}