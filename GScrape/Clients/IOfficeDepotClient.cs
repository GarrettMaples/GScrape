using GScrape.Requests.OfficeDepot.Json;
using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace GScrape.Clients
{
    public interface IOfficeDepotClient
    {
        [Get("/catalog/search.do?Ntt=3090+rtx")]
        public Task<HttpResponseMessage> Get3090SearchPage();

        [Get("/mobile/getAjaxPriceListFromService.do?items={skus}&mapBySkuId=true&includeOos=true")]
        public Task<ItemInfoPayload> GetItemInfoJson(string skus);
    }
}