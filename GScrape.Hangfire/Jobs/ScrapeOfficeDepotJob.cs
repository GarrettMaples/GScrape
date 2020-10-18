using GScrape.Requests;
using GScrape.Requests.OfficeDepot;
using Hangfire;
using MediatR;
using System.Threading.Tasks;

namespace GScrape.Hangfire.Jobs
{
    internal class ScrapeOfficeDepotJob : IHangfireJob
    {
        private readonly IMediator _mediator;

        public ScrapeOfficeDepotJob(IMediator mediator)
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