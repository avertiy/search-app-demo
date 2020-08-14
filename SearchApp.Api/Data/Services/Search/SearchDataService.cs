using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchApp.Api.Data.Contracts;
using SearchApp.Api.Data.Models.Search;
using SearchApp.Api.Models;
using TanvirArjel.EFCore.GenericRepository;

namespace SearchApp.Api.Data.Services.Search
{
    class SearchDataService : ISearchDataService
    {
        private readonly IRepository _repository;

        public SearchDataService(IRepository repository)
        {
            _repository = repository;
        }
        
        public async Task SaveSearchResults(SearchRequest request, IEnumerable<ItemModel> items)
        {
            try
            {
                //this could be done through AutoMapper  but for simplicity 
                var entities = items.Select(r => new SearchResultLine()
                {
                    EnteredDate = DateTime.UtcNow,
                    Request = request.Text,
                    Title = r.Title,
                    SearchEngine = r.SearchEngine
                });
                await _repository.InsertEntitiesAsync(entities);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //log & handle error;
            }
        }
    }
}
