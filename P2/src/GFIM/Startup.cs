using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GFAB.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using GFAB.View;

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
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
              });
      });


      services.Configure<ApiBehaviorOptions>(options =>
      {
        options.InvalidModelStateResponseFactory = context =>
        {
          return new BadRequestObjectResult(new ErrorModelView("request body not formatted"));
        };
      });

      // services.AddDbContext<SQLite3DbContext>(
      //   options => options.UseSqlite(Configuration.GetConnectionString("sqlite3"))
      // );

      services.AddDbContext<InMemoryDbContext>(
        options => options.UseInMemoryDatabase("inmemory")
      );

      services.AddScoped<RepositoryFactory, InMemoryRepositoryFactoryImpl>();


      // Load existing allergens, ingredients, meal types and descriptors

      var jsonOptions = new JsonSerializerOptions
      {

        PropertyNameCaseInsensitive = true,

        PropertyNamingPolicy = JsonNamingPolicy.CamelCase

      };

      services.AddHttpClient("gfmm", c =>
        {
          c.BaseAddress = new Uri(Environment.GetEnvironmentVariable("GFMM_URL"));
        });
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
