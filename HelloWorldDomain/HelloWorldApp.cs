using System.Threading.Tasks;
using HelloWorldDomain.GreetingPerformer;
using HelloWorldDomain.GreetingProvider;

namespace HelloWorldDomain
{
    public class HelloWorldApp
    {
        private readonly IGreetingProvider _greetingProvider;
        private readonly ICanDoGreeting _canDoGreeting;

        public HelloWorldApp(IGreetingProvider greetingProvider, ICanDoGreeting canDoGreeting)
        {
            _greetingProvider = greetingProvider;
            _canDoGreeting = canDoGreeting;
        }

        public async Task Run()
        {
            var greeting = await _greetingProvider.GetGreeting();
            await _canDoGreeting.SayHello(greeting);
        }
    }
}