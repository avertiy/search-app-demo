using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using SearchApp.Api.Contracts.Search;
using SearchApp.Api.Models;

namespace SearchApp.Api.Services.Search
{
    class GoogleSearchProvider : ISearchProvider
    {
        protected string Name => "Google";

        public async Task<IEnumerable<ItemModel>> SearchAsync(string text, int count)
        {
            try
            {
                var uriString = "https://google.com/search?q=" + text.Trim();

                using (var client = new WebClient())
                {
                    var html = await client.DownloadStringTaskAsync(uriString);

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);
                    var titleNodes = doc.DocumentNode.SelectNodes("//div/a/h3[@class='zBAuLc']");

                    if (titleNodes == null)
                        throw new Exception("search page document structure might have changed");

                    var items = titleNodes.Take(count).Select(n => new ItemModel()
                    {
                        Title = n.InnerText,
                        SearchEngine = Name,
                    }).ToList();
                    return items;
                }
            }
            catch (Exception ex)
            {
                //log and handle error somehow...
                return new ItemModel[] { };
            }
        }
    }
}