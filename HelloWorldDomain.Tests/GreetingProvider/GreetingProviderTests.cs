using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using HelloWorldDomain.GreetingProvider;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace HelloWorldDomain.Tests.GreetingProvider
{
    public class GreetingProviderTests
    {
        private const string ExpectedGreeting = "Hello World";

        [Theory]
        [InlineData(ExpectedGreeting)]
        public async Task TestHardCodedGreetingProvider(string expectedGreeting)
        {
            var greetingProvider = new HardCodedGreetingProvider();
            (await greetingProvider.GetGreeting())
                .Should().Be(expectedGreeting);
        }

        [Theory]
        [InlineData(ExpectedGreeting)]
        public async Task TestRestGreetingProvider(string expectedGreeting)
        {
            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();
            var fakeHttpMessageHandler = FakeHttpMessageHandler.FactoryWithJsonBody(expectedGreeting);
            var fakeHttpClient = new HttpClient(fakeHttpMessageHandler);

            httpClientFactoryMock.CreateClient().Returns(fakeHttpClient);

            var greetingProvider = new RestGreetingProvider(Substitute.For<ILogger<RestGreetingProvider>>(), httpClientFactoryMock, FactoryServicesConfig());
            (await greetingProvider.GetGreeting())
                .Should().Be(expectedGreeting);
        }

        private static ServicesConfig FactoryServicesConfig() => new ServicesConfig {HelloWorldServiceBaseAddress = "http://fake"};
    }
}