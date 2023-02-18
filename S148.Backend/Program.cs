using Autofac.Extensions.DependencyInjection;
using S148.Backend.Extensibility;

namespace S148.Backend
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string? environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config =>
                {
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    if (!environmentName.IsNullOrEmpty())
                    {
                        config.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);
                    }
                    config.AddEnvironmentVariables();
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webHostBuilder => {
                    webHostBuilder
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseIISIntegration()
                        .UseStartup<Startup>();
                })
                .Build();

            host.Run();
        }
    }
}