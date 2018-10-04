using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using pizzadon.Repositories;

namespace pizzadon
{
  public class Startup
  {
    private readonly string _ConnectionString = "";
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
      //grabs connection string from appsetting.json
      _ConnectionString = configuration.GetSection("DB").GetValue<string>("mySQLConnectionString");
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddTransient<IDbConnection>(x => CreateDBContext());
      services.AddTransient<PizzaRepository>();
      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      //app.UseHttpsRedirection();
      app.UseMvc();
    }
    private IDbConnection CreateDBContext()
    {
      IDbConnection connection = new MySqlConnection(_ConnectionString);
      connection.Open();
      return connection;
    }
  }
}
