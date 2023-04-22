using System.Text;
using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NovaPoshtaApi;
using S148.Backend.AutofacModules;
using S148.Backend.Domain;
using S148.Backend.Extensibility;

namespace S148.Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            EncodingProvider provider = CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(provider);

            services.AddDbContext<DatabaseContext>(
                options => options.UseNpgsql(
                    Configuration.GetConnectionString(ConfigurationTokens.DbConnectionStringToken)));
            services.AddMvc().AddControllersAsServices();
            services.AddOptions();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "webApiGitTest", Version = "v1" });
                c.EnableAnnotations();
            });
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                            .WithOrigins(Configuration[ConfigurationTokens.FrontendAppUrlToken])
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
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
            builder.Register(_ => new ApiConnection(Configuration[ConfigurationTokens.NovaPoshtaApiKeyToken], NovaPoshtaClient.BaseUri))
                .As<IApiConnection>();
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "webApiGitTest v1"));

            app.UseCors();
            app.UseExceptionHandler("/Error");
            app.UseHsts();

            var builder = WebApplication.CreateBuilder();
            builder.Host.ConfigureLogging(logging => { logging.AddConsole(); });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });

            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();
            if (context == null)
            {
                throw new ArgumentException("The database context was not created");
            }

            context.Database.Migrate();
        }
    }
}