﻿using GScrape.Requests.BestBuy;
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
            var request = new BestBuyNotificationRequest();
            await _mediator.Send(request);
        }
    }
}