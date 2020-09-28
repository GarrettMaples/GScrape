using GScrape.Requests.Newegg;
using GScrape.Requests.OfficeDepot;
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
            var request = new NeweggRequest();
            await _mediator.Send(request);
            
            var officeDepotRequest = new OfficeDepotRequest();
            await _mediator.Send(officeDepotRequest);
        }
    }
}