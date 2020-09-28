﻿using GScrape.Requests.Newegg;
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
            var request = new NeweggScrapeRequest();
            var results = await _mediator.Send(request);

            await foreach (var result in results)
            {
                await _mediator.Send(result);
            }
        }
    }
}