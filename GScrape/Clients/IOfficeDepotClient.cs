using GScrape.Requests.OfficeDepot;
using Refit;
using System.Threading.Tasks;

namespace GScrape.Clients
{
    public interface IOfficeDepotClient
    {
        [Get("/catalog/search.do?Ntt=3090+rtx")]
        public Task<string> Get3090SearchPage();

        [Get("/mobile/getAjaxPriceListFromService.do?items={skus}&mapBySkuId=true&includeOos=true")]
        public Task<ItemInfoJson> GetItemInfoJson(string skus);
    }
}