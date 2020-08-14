using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SearchApp.Api.Contracts;
using SearchApp.Api.Contracts.Search;
using SearchApp.Api.Data;
using SearchApp.Api.Data.Contracts;
using SearchApp.Api.Data.Services.Search;
using SearchApp.Api.Implementations;
using SearchApp.Api.Services.Search;
using TanvirArjel.EFCore.GenericRepository;

namespace SearchApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Search API", Version = "v1" });
            });

            //register data services
            services.AddDbContext<SearchDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddGenericRepository<SearchDbContext>();
            services.AddScoped<ISearchDataService, SearchDataService>();

            //register api services
            services.AddScoped<ISearchApi, SearchApi>();
            services.AddScoped<ISearchEngine, SearchEngine>();
            services.AddScoped<GoogleSearchProvider>();
            services.AddScoped<BingSearchProvider>();

            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            //});

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOriginPolicy", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Search API V1");
            });


            //initialize db 
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<SearchDbContext>();
                context.Database.EnsureCreated();
            }


            app.UseRouting();
            app.UseCors("AllowOriginPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
