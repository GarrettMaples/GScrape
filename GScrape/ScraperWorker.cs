using GScrape.Requests;
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
            var request = new NeweggScrapeRequest();
            var result = await _mediator.Send(request);
            await _mediator.Send(result);
        }
    }
}