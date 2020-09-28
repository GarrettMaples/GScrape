using Refit;
using System.Threading.Tasks;

namespace GScrape.Clients
{
    public interface INeweggClient
    {
        [Get("/p/pl?N=100007709%20601357248")]
        Task<string> Get3090SearchPage();

        [Get("/p/pl?N=100007709%20601357247")]
        Task<string> Get3080SearchPage();
    }
}