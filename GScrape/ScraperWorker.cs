using GScrape.Requests.Newegg;
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
            var results = await _mediator.Send(request);

            await foreach (var result in results)
            {
                await _mediator.Send(result);
            }
        }
    }
}