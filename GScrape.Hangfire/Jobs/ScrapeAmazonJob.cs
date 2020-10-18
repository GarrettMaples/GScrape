using GScrape.Requests;
using GScrape.Requests.Amazon;
using Hangfire;
using MediatR;
using System.Threading.Tasks;

namespace GScrape.Hangfire.Jobs
{
    internal class ScrapeAmazonJob : IHangfireJob
    {
        private readonly IMediator _mediator;

        public ScrapeAmazonJob(IMediator mediator)
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