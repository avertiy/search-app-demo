using System.Threading.Tasks;
using SearchApp.Api.Contracts;
using SearchApp.Api.Contracts.Search;
using SearchApp.Api.Data.Contracts;
using SearchApp.Api.Models;

namespace SearchApp.Api.Implementations
{
    class SearchApi : ISearchApi
    {
        private readonly ISearchDataService _searchDataService;
        private readonly ISearchEngine _searchEngine;

        public SearchApi(ISearchDataService searchDataService, ISearchEngine searchEngine)
        {
            _searchDataService = searchDataService;
            _searchEngine = searchEngine;
        }

        public async Task<SearchResponse> Search(SearchRequest request)
        {
            var response = await _searchEngine.SearchAsync(request);

            if (response.Success)
            {
                await _searchDataService.SaveSearchResults(request, response.Items);
            }
            return response;
        }
    }

    
}
