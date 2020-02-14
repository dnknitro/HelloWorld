using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace HelloWorldApp
{
    internal class HelloWorldAppProgram
    {
        private static async Task Main()
        {
            var services = new HelloWorldAppProgramStartup().ConfigureServices(new ServiceCollection());
            await using var serviceProvider = services.BuildServiceProvider();

            var app = serviceProvider.GetRequiredService<HelloWorldDomain.HelloWorldApp>();
            await app.Run();
        }
    }
}