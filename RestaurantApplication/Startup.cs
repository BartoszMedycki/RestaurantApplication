using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestarantApplicationDataBase.Repositories;

namespace RestaurantApplication
{
    public class Startup
    {
        private string ConnectionString   { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = "Server=.;Database=RestaurantApplicationDataBase;Trusted_Connection=True;";
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RestarantApplicationDataBase.RestaurantApplicationDbContext>(options => options.UseSqlServer(ConnectionString));
            services.AddScoped<RestarantApplicationDataBase.Mappers.RestaurantMapper>();
            services.AddScoped<RestarantApplicationDataBase.Mappers.CreateRestaurantDataModelMapper>();
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddControllers();
            services.AddAutoMapper(this.GetType().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, IRestaurantRepository restaurantRepository)
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

            var dataBase = serviceProvider.GetService<RestarantApplicationDataBase.RestaurantApplicationDbContext>();
            dataBase.Database.EnsureCreated();

            
        }
    }
}
