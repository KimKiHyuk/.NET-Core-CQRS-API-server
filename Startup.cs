using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestApi.Commands;
using RestApi.Dto;
using RestApi.Queries;
using RestApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace RestApi
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
            services.AddScoped<IQueryService<AboutMeDto>, AboutMeQuery>(ctor => new AboutMeQuery(Configuration["ConnectionString"]));
            services.AddScoped<ICommandService<AboutMeDto>, AboutMeCommandService>();
             services.AddDbContext<DatabaseContext>(optionsAction: optionsBuilder =>
     optionsBuilder.UseSqlServer(Configuration["ConnectionString"],
     optionsAction => optionsAction.MigrationsAssembly(typeof(DatabaseContext).GetTypeInfo().Assembly.GetName().Name)));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
