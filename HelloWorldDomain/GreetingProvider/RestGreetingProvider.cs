using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HelloWorldDomain.GreetingProvider
{
    public class RestGreetingProvider : IGreetingProvider
    {
        private readonly ILogger _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ServicesConfig _servicesConfig;

        public RestGreetingProvider(ILogger<RestGreetingProvider> logger, IHttpClientFactory httpClientFactory, ServicesConfig servicesConfig)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _servicesConfig = servicesConfig;
        }

        public async Task<string> GetGreeting()
        {
            using var httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(_servicesConfig.HelloWorldServiceBaseAddress);

            _logger.LogDebug($"Downloading greeting from {_servicesConfig.HelloWorldServiceBaseAddress}{_servicesConfig.GreetingEndpoint}");

            using var httpResponseMessage = await httpClient.GetAsync(_servicesConfig.GreetingEndpoint);

            var contentBody = await httpResponseMessage.Content.ReadAsStringAsync();

            var greeting = JsonSerializer.Deserialize<string>(contentBody, new JsonSerializerOptions());

            _logger.LogDebug($"Downloaded greeting '{greeting}'");

            return greeting;
        }
    }
}