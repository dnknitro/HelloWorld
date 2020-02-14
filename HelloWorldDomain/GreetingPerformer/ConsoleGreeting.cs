using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HelloWorldDomain.GreetingPerformer
{
    public class ConsoleGreeting : ICanDoGreeting
    {
        private readonly ILogger _logger;

        public ConsoleGreeting(ILogger<ConsoleGreeting> logger)
        {
            _logger = logger;
        }

        public Task SayHello(string greeting)
        {
            _logger.LogDebug($"{nameof(SayHello)} greeting='{greeting}'");
            Console.WriteLine(greeting);
            return Task.CompletedTask;
        }
    }
}