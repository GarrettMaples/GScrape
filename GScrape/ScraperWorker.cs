using GScrape.Requests;
using GScrape.Requests.Amazon;
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

            // var bestBuyNotificationRequest = new NotificationRequest(() => new Requests.BestBuy.ScrapeRequest());
            // await _mediator.Send(bestBuyNotificationRequest);

            var amazonNotificationRequest = new NotificationRequest(() => new ScrapeRequest());
            await _mediator.Send(amazonNotificationRequest);
        }
    }
}