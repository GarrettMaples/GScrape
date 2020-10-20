using GScrape.Requests;
using GScrape.Requests.Amazon;
using GScrape.Requests.Walmart;
using GScrape.Results;
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

            // var bestBuyNotificationRequest = new NotificationRequest(() => new Requests.BestBuy.ItemPriceScrapeRequest());
            // await _mediator.Send(bestBuyNotificationRequest);

            // var amazonNotificationRequest = new NotificationRequest<ScrapeItem>(() => new ScrapeRequest());
            // await _mediator.Send(amazonNotificationRequest);
            
            var walmartNotificationRequest = new NotificationRequest<ItemPriceScrapeItem>(() => new ItemPriceScrapeRequest());
            await _mediator.Send(walmartNotificationRequest);
        }
    }
}