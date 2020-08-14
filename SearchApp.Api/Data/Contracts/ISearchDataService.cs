using System.Collections.Generic;
using System.Threading.Tasks;
using SearchApp.Api.Models;

namespace SearchApp.Api.Data.Contracts
{
    public interface ISearchDataService
    {
        Task SaveSearchResults(SearchRequest request, IEnumerable<ItemModel> responseItems);
    }
}