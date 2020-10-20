using GScrape.Requests;
using GScrape.Requests.Walmart;
using GScrape.Results;
using Hangfire;
using MediatR;
using System.Threading.Tasks;

namespace GScrape.Hangfire.Jobs
{
    public class ScrapeWalmartPricesJob : IHangfireJob
    {
        private readonly IMediator _mediator;

        public ScrapeWalmartPricesJob(IMediator mediator)
        {
            _mediator = mediator;
        }

        public string CronExpression => Cron.Minutely();

        public async Task DoWork()
        {
            var notificationRequest = new NotificationRequest<ItemPriceScrapeItem>(() => new ItemPriceScrapeRequest());
            await _mediator.Send(notificationRequest);
        }
    }
}