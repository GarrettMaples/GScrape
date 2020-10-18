using GScrape.Requests;
using GScrape.Requests.BestBuy;
using Hangfire;
using MediatR;
using System.Threading.Tasks;

namespace GScrape.Hangfire.Jobs
{
    internal class ScrapeBestBuyJob : IHangfireJob
    {
        private readonly IMediator _mediator;

        public ScrapeBestBuyJob(IMediator mediator)
        {
            _mediator = mediator;
        }

        public string CronExpression => Cron.Minutely();

        public async Task DoWork()
        {
            var notificationRequest = new NotificationRequest(() => new ScrapeRequest());
            await _mediator.Send(notificationRequest);
        }
    }
}