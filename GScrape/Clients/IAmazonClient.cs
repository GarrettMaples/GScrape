using Refit;
using System.Threading.Tasks;

namespace GScrape.Clients
{
    public interface IAmazonClient
    {
        [Get("/stores/page/CFF83A4D-9DEC-4003-AC7E-96DF4170CED0")]
        Task<string> Get3090Page();
        [Get("/stores/page/6B204EA4-AAAC-4776-82B1-D7C3BD9DDC82")]
        Task<string> Get3080Page();
    }
}