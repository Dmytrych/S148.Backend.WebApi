using System.Reflection;
using System.Text;
using System.Text.Json;
using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NovaPoshtaApi;
using S148.Backend.AutofacModules;
using S148.Backend.Domain;
using S148.Backend.Extensibility.Messaging;

namespace S148.Backend
{
    public class Startup
    {
        private const string DbConnectionStringToken = "PgSqlConnectionString";
        private const string NovaPoshtaApiKeyToken = "NovaPoshtaApiKey";
        private const string FrontendAppUrlToken = "FrontendAppUrl";
        private const string ProcessResultCodeMappingFileToken = "ProcessResultCodeMappingFile";

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
                    Configuration.GetConnectionString(DbConnectionStringToken)));
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
                            .WithOrigins(Configuration[FrontendAppUrlToken])
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
            builder.Register(_ => new ApiConnection(Configuration[NovaPoshtaApiKeyToken], NovaPoshtaClient.BaseUri))
                .As<IApiConnection>();

            var processResultMapping = LoadProcessResultCodeMapping();
            var mappingRegistry = new ProcessResultCodeRegistry(processResultMapping);
            builder.Register(_ => mappingRegistry).As<IProcessResultCodeRegistry>();
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

        private IReadOnlyDictionary<string, int> LoadProcessResultCodeMapping()
        {
            var fileName = Configuration[ProcessResultCodeMappingFileToken];
            var assembly = Assembly.GetExecutingAssembly();

            var embeddedMappingFilePath = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith(fileName));

            using Stream stream = assembly.GetManifestResourceStream(embeddedMappingFilePath);
            if (stream == null)
            {
                throw new ArgumentException($"Could not find process result code mapping file: {fileName}");
            }

            using StreamReader reader = new StreamReader(stream);

            return JsonSerializer.Deserialize<Dictionary<string, int>>(reader.ReadToEnd());
        }
    }
}