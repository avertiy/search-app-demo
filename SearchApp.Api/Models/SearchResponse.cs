using System.Collections.Generic;

namespace SearchApp.Api.Models
{
    public class SearchResponse: Response
    {
        public List<ItemModel> Items { get; set; }
    }
}