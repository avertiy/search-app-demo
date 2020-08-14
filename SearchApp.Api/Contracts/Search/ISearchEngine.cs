using System.Collections.Generic;
using System.Threading.Tasks;
using SearchApp.Api.Models;

namespace SearchApp.Api.Contracts.Search
{
    public interface ISearchEngine
    {
        Task<SearchResponse> SearchAsync(SearchRequest text);
    }

    public interface ISearchProvider
    {
        Task<IEnumerable<ItemModel>> SearchAsync(string text, int count);
    }
}