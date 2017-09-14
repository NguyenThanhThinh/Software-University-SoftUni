using Microsoft.VisualStudio.TestTools.UnitTesting;
using _06.Twiter.Models;

namespace _06.Twiter.Tests
{
    [TestClass]
    public class TwiterTests
    {
        public readonly ITweetable tweet = new Tweet("Test message");

        [TestMethod]
        public void TestClientConstructorIsStoringDataProperly()
        {
            IClient client = new Client(this.tweet);
            Assert.AreEqual(this.tweet.Content, client.Tweet.Content);
        }

        [TestMethod]
        public void TestTweetConstructorIsStoringDataProperly()
        {
            string message = "Test";
            ITweetable currentTweet = new Tweet(message);
            Assert.AreEqual(currentTweet.Content, message);
        }
    }
}