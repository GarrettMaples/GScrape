using MediatR;
using System.Threading.Tasks;
using GScrape.Requests;

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
            // var request = new NeweggNotificationRequest();
            // await _mediator.Send(request);

            // var officeDepotRequest = new OfficeDepotNotificationRequest();
            // await _mediator.Send(officeDepotRequest);
            
            // var bestBuyRequest = new BestBuyNotificationRequest();
            // await _mediator.Send(bestBuyRequest);

            var amazonNotificationRequest = new Requests.Amazon.NotificationRequest();
            await _mediator.Send(amazonNotificationRequest);
        }
    }
}