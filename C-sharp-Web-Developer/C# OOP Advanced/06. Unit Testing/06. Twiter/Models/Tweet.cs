namespace _06.Twiter.Models
{
    public class Tweet : ITweetable
    {
        private string content;

        public Tweet(string content)
        {
            this.Content = content;
        }

        public string Content
        {
            get { return this.content; }
            private set { this.content = value; }
        }
    }
}