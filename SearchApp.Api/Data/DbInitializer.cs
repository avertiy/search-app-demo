using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchApp.Api.Data
{
    internal static class DbInitializer
    {
        public static void Initialize(SearchDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
