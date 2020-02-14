using System;
using System.IO;
using HelloWorldDomain;
using HelloWorldDomain.GreetingPerformer;
using HelloWorldDomain.GreetingProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HelloWorldApp
{
    public class HelloWorldAppProgramStartup
    {
        public IConfigurationRoot Configuration { get; }

        public HelloWorldAppProgramStartup()
        {
            var environment = Environment.GetEnvironmentVariable("AppEnvironment") ?? "Development";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }


        public IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddLogging(builder => builder
                .AddConfiguration(Configuration.GetSection("Logging"))
                .AddDebug());
            services.AddSingleton(Configuration);

            services.AddSingleton(serviceProvider => serviceProvider
                .GetRequiredService<IConfigurationRoot>()
                .GetSection("Services")
                .Get<ServicesConfig>());

            services.AddTransient<HelloWorldDomain.HelloWorldApp>();
            services.AddTransient<IGreetingProvider, RestGreetingProvider>();

            var iCanDoGreetingImplementationType = Type.GetType(Configuration["ICanDoGreetingImplementationType"]);

            services.AddTransient(iCanDoGreetingImplementationType);

            services.AddTransient(serviceProvider => (ICanDoGreeting) serviceProvider.GetRequiredService(iCanDoGreetingImplementationType));

            return services;
        }
    }
}