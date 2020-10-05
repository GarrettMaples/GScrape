using Refit;
using System.Threading.Tasks;

namespace GScrape.Clients
{
    public interface IBestBuyClient
    {
        [Get("/site/searchpage.jsp?st=3090+rtx")]
        Task<string> Get3090SearchPage();
        
        [Get("/site/searchpage.jsp?st=3080+rtx")]
        Task<string> Get3080SearchPage();
    }
}