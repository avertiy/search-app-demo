using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SearchApp.Api.Data.Models.Search
{
    public class SearchResultLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// Bing/Google
        /// </summary>
        public string SearchEngine { get; set; }
        /// <summary>
        /// search phrase used
        /// </summary>
        public string Request { get; set; }
        public string Title { get; set; }
        /// <summary>
        /// date and time of the request
        /// </summary>
        public DateTime EnteredDate { get; set; }
    }
}