namespace LearningSystem.Services.Html.Implementations
{
    using Ganss.XSS;

    public class HtmlService : IHtmlService
    {
        private readonly HtmlSanitizer htmlSanitizer;

        public HtmlService()
        {
            this.htmlSanitizer = new HtmlSanitizer();
            this.htmlSanitizer.AllowedAttributes.Add("class");
        }

        public string HtmlSanitizer(string html)
        {
            return this.htmlSanitizer.Sanitize(html);
        }
    }
}