namespace PullRequestQuantifier.GitHub.Client
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices((context, serviceCollection) =>
                {
                    serviceCollection.AddHealthChecks();
                    serviceCollection.RegisterServices(context.Configuration);
                });
    }
}
