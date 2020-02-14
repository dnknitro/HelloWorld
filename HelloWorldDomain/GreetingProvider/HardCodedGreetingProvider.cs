using System.Threading.Tasks;

namespace HelloWorldDomain.GreetingProvider
{
    public class HardCodedGreetingProvider : IGreetingProvider
    {
        public Task<string> GetGreeting()
        {
            return Task.FromResult("Hello World");
        }
    }
}