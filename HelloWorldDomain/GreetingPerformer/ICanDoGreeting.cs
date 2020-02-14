using System.Threading.Tasks;

namespace HelloWorldDomain.GreetingPerformer
{
    public interface ICanDoGreeting
    {
        Task SayHello(string greeting);
    }
}