using System;

namespace _06.Twiter.Models
{
    public class Client : IClient
    {
        private ITweetable tweet;

        public Client(ITweetable tweet)
        {
            this.Tweet = tweet;
        }

        public ITweetable Tweet
        {
            get { return this.tweet; }
            private set { this.tweet = value; }
        }

        public void WriteToConsole()
        {
            Console.WriteLine(this.Tweet.Content);
            SendToServer();
        }

        private void SendToServer()
        {
            Console.WriteLine("Sended to Server!");
        }
    }
}