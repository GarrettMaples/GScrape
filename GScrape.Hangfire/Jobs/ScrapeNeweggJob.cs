using GScrape.Requests;
using GScrape.Requests.Newegg;
using GScrape.Results;
using Hangfire;
using MediatR;
using System.Threading.Tasks;

namespace GScrape.Hangfire.Jobs
{
    internal class ScrapeNeweggJob : IHangfireJob
    {
        private readonly IMediator _mediator;

        public ScrapeNeweggJob(IMediator mediator)
        {
            _mediator = mediator;
        }

        public string CronExpression => Cron.Minutely();

        public async Task DoWork()
        {
            var notificationRequest = new NotificationRequest<ScrapeItem>(() => new ScrapeRequest());
            await _mediator.Send(notificationRequest);
        }
    }
}