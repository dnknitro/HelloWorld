using System;
using System.Threading.Tasks;

namespace HelloWorldDomain.GreetingPerformer.FutureImplementations
{
    public class DBGreeting : ICanDoGreeting
    {
        public Task SayHello(string greeting)
        {
            throw new NotImplementedException($"{nameof(SayHello)} not implemented in {nameof(DBGreeting)}");
        }
    }
}