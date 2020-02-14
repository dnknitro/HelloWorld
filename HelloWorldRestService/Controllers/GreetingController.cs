using System.Threading.Tasks;
using HelloWorldDomain.GreetingProvider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorldRestService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class GreetingController : ControllerBase
    {
        private readonly ILogger<GreetingController> _logger;
        private readonly IGreetingProvider _greetingProvider;

        public GreetingController(ILogger<GreetingController> logger, IGreetingProvider greetingProvider)
        {
            _logger = logger;
            _greetingProvider = greetingProvider;
        }

        /// <summary>
        ///     Returns greeting message in English language
        /// </summary>
        /// <response code="200">Greeting message.</response>
        [HttpGet]
        public async Task<string> Get()
        {
            var greeting = await _greetingProvider.GetGreeting();
            _logger.LogInformation($"Returning greeting '{greeting}'");
            return greeting;
        }
    }
}