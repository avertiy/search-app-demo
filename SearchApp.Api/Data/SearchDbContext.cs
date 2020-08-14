using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SearchApp.Api.Data.Models.Search;

namespace SearchApp.Api.Data
{
    public class SearchDbContext : DbContext
    {
        public SearchDbContext(DbContextOptions<SearchDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchResultLine>().ToTable("SearchResult");
        }

        public DbSet<SearchResultLine> Courses { get; set; }
    }
}
