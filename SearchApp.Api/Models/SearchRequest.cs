using System.ComponentModel;

namespace SearchApp.Api.Models
{
    public class SearchRequest
    {
        [DefaultValue("cats")]
        public string Text { get; set; }
    }
}