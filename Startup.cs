using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace S148.Backend
{
    public class Startup
    {
      public Startup(IConfiguration configuration)
      {
        this.Configuration = configuration;
      }

      public IConfiguration Configuration { get; private set; }

      public ILifetimeScope AutofacContainer { get; private set; }
      
      public void ConfigureServices(IServiceCollection services)
      {
        services.AddMvc().AddControllersAsServices();
        services.AddOptions();
      }
      
      public void ConfigureContainer(ContainerBuilder builder)
      {
        builder.RegisterModule<BackendAutofacModule>();
      }

      public void Configure(
        IApplicationBuilder app,
        ILoggerFactory loggerFactory)
      {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
          endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
        });
        AutofacContainer = app.ApplicationServices.GetAutofacRoot();
      }
    }
}