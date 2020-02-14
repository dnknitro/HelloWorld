using System;
using System.Threading.Tasks;
using FluentAssertions;
using HelloWorldDomain.GreetingPerformer;
using HelloWorldDomain.GreetingPerformer.FutureImplementations;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace HelloWorldDomain.Tests.GreetingPerformer
{
    public class GreetingPerformerTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Hello World")]
        [InlineData("Привіт Світе")]
        public async Task TestConsoleGreetingSmoke(string greeting)
        {
            await new ConsoleGreeting(Substitute.For<ILogger<ConsoleGreeting>>())
                .SayHello(greeting);
        }

        [Fact]
        public void TestDBGreeting()
        {
            Action sayHello = () => new DBGreeting().SayHello("Yo");
            sayHello.Should().Throw<NotImplementedException>()
                .WithMessage("SayHello not implemented in DBGreeting");
        }
    }
}