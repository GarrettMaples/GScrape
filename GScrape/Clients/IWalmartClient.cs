using Refit;
using System.Threading.Tasks;

namespace GScrape.Clients
{
    public interface IWalmartClient
    {
        [Get("/ip/Honeywell-HEPA-Allergen-Remover-Air-Purifier-Reduces-up-to-99-9-of-certain-viruses-bacteria-and-mold-spores-HPA300-Black/37770927")]
        Task<string> GetHoneywellHepaFilter();
    }
}