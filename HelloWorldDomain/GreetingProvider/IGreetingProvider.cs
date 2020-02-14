using System.Threading.Tasks;

namespace HelloWorldDomain.GreetingProvider
{
    public interface IGreetingProvider
    {
        Task<string> GetGreeting();
    }
}