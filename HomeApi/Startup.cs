using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApi.DataAccessLayer;
using HomeApi.DataAccessLayer.Entity;
using HomeApi.DataAccessLayer.Entity.Models;
using HomeApi.DataAccessLayer.Repositories;
using HomeApi.DataAccessLayer.Repositories.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HomeApi
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
            services.Configure<Mongosettings>(options =>
            {
                options.Connection = Configuration.GetSection("MongoSettings:Connection").Value;
                options.DatabaseName = Configuration.GetSection("MongoSettings:DatabaseName").Value;
            });
            services.AddScoped<IMongoDBContext, MongoDBContext>();

            services.AddScoped<IShoppingRepository, ShoppingRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddSwaggerDocument();
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

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
