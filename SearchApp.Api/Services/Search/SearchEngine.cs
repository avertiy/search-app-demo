using System.Collections.Generic;
using System.Threading.Tasks;
using SearchApp.Api.Contracts.Search;
using SearchApp.Api.Models;

namespace SearchApp.Api.Services.Search
{
    class SearchEngine :ISearchEngine
    {
        private readonly GoogleSearchProvider _googleSearch;
        private readonly BingSearchProvider _bingSearch;

        public SearchEngine(GoogleSearchProvider googleSearch, BingSearchProvider bingSearch)
        {
            _googleSearch = googleSearch;
            _bingSearch = bingSearch;
        }

        public async Task<SearchResponse> SearchAsync(SearchRequest request)
        {
            var googleSearchTask = _googleSearch.SearchAsync(request.Text, 5);
            var bingSearchTask = _bingSearch.SearchAsync(request.Text, 5);
            var searchResults = await Task.WhenAll(googleSearchTask, bingSearchTask);
            var response = new SearchResponse(){ Items = new List<ItemModel>()};

            foreach (var set in searchResults)
                response.Items.AddRange(set);

            return response;
        }
    }
}