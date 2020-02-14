using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using HelloWorldDomain.GreetingPerformer;
using HelloWorldDomain.GreetingProvider;
using NSubstitute;
using Xunit;

namespace HelloWorldDomain.Tests
{
    public class HelloWorldAppTests
    {
        [Fact]
        public async Task TestHelloWorldAppIntegration()
        {
            var greetingProvider = Substitute.For<IGreetingProvider>();
            var canDoGreeting = Substitute.For<ICanDoGreeting>();

            await new HelloWorldApp(greetingProvider, canDoGreeting)
                .Run();

            greetingProvider.ReceivedCalls().Count().Should().Be(1);
            canDoGreeting.ReceivedCalls().Count().Should().Be(1);
        }
    }
}