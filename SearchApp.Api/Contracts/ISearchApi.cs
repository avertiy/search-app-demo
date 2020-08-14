using System.Threading.Tasks;
using SearchApp.Api.Models;

namespace SearchApp.Api.Contracts
{
    public interface ISearchApi
    {
        Task<SearchResponse> Search(SearchRequest request);
    }
}