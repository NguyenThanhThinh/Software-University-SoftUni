using _06.Twiter.Models;

namespace _06.Twiter
{
    class Startup
    {
        static void Main()
        {
            ITweetable tweet = new Tweet("This is my test message.");
            IClient client = new Client(tweet);
            client.WriteToConsole();
        }
    }
}