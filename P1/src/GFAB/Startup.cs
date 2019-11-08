using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GFAB.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.IO;
using GFAB.View;
using GFAB.Model;

namespace GFAB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddCors(options =>
        {
            options.AddPolicy(MyAllowSpecificOrigins,
            builder =>
            {
                builder.WithOrigins("http://localhost:3000");
            });
        });

            // services.AddDbContext<SQLite3DbContext>(
            //   options => options.UseSqlite(Configuration.GetConnectionString("sqlite3"))
            // );

            services.AddDbContext<InMemoryDbContext>(
              options => options.UseInMemoryDatabase("inmemory")
            );

            services.AddScoped<RepositoryFactory, InMemoryRepositoryFactoryImpl>();


            // Load existing allergens, ingredients, meal types and descriptors

            var jsonOptions = new JsonSerializerOptions{

              PropertyNameCaseInsensitive = true,

              PropertyNamingPolicy = JsonNamingPolicy.CamelCase

            };

            var jsonString = File.ReadAllText("existingdata.json");

            ExistingDataModelView modelview = JsonSerializer.Deserialize<ExistingDataModelView>(jsonString, jsonOptions);

            ExistingAllergensService.InjectAllergens(modelview.Allergens);

            ExistingIngredientsService.InjectIngredients(modelview.Ingredients);

            ExistingMealTypesService.InjectMealTypes(modelview.MealTypes);

            ExistingDescriptorsService.InjectDescriptors(modelview.Descriptors);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                endpoints.MapControllers();
            });

            app.UseHttpsRedirection();
        }
    }
}
