using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using S148.Backend.Domain;
using S148.Backend.Utils;

namespace S148.Backend
{
    public class Startup
    {
      public Startup(IConfiguration configuration)
      {
        Configuration = configuration;
      }

      public IConfiguration Configuration { get; private set; }

      public void ConfigureServices(IServiceCollection services)
      {
        services.AddMvc().AddControllersAsServices();
        services.AddOptions();
      }

      public void ConfigureContainer(ContainerBuilder builder)
      {
        builder.RegisterAllModules();

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
        using var scope = app.ApplicationServices.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        context.Database.EnsureCreated();
        context.Database.Migrate();
      }
    }
}