using System.Text;
using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NovaPoshtaApi;
using S148.Backend.AutofacModules;
using S148.Backend.Domain;
using S148.Backend.Extensibility.NovaPoshta;

namespace S148.Backend
{
    public class Startup
    {
      private const string NovaPoshtaApiKeyToken = "NovaPoshtaApiKey";

      public Startup(IConfiguration configuration)
      {
        Configuration = configuration;
      }

      public IConfiguration Configuration { get; private set; }

      public void ConfigureServices(IServiceCollection services)
      {
        EncodingProvider provider = CodePagesEncodingProvider.Instance;
        Encoding.RegisterProvider(provider);

        services.AddDbContext<DatabaseContext>();
        services.AddMvc().AddControllersAsServices();
        services.AddOptions();;
        services.AddSwaggerGen(c =>
        {
          c.SwaggerDoc("v1", new OpenApiInfo { Title = "webApiGitTest", Version = "v1" });
          c.EnableAnnotations();
        });
      }

      public void ConfigureContainer(ContainerBuilder builder)
      {
        var modules = ModuleRegistry.GetAutofacModules(Configuration);
        foreach (var module in modules)
        {
          builder.RegisterModule(module);
        }

        var assem = AppDomain.CurrentDomain.GetAssemblies();
        builder.RegisterAutoMapper(true, assem);

        builder.Register(x => new ApiConnection(Configuration[NovaPoshtaApiKeyToken], NovaPoshtaClient.BaseUri)).As<IApiConnection>();
      }

      public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env)
      {
        if (env.IsDevelopment())
        {
          app.UseDeveloperExceptionPage();
          app.UseSwagger();
          app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "webApiGitTest v1"));
        }
        
        app.UseExceptionHandler("/Error");
        app.UseHsts();

        var builder = WebApplication.CreateBuilder();
        builder.Host.ConfigureLogging(logging =>
        {
          logging.AddConsole();
        });

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
          endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
        });

        var context = new DatabaseContext(Configuration);
        context.Database.Migrate();
      }
    }
}