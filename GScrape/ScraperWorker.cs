using GScrape.Clients;
using GScrape.Requests;
using MediatR;
using System;
using System.Text.RegularExpressions;
using System.Threading;
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
            var request = new NeweggScrapeRequest();
            await _mediator.Send(request);
        }
    }
}