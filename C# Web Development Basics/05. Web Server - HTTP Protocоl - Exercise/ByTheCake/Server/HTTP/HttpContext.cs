namespace ByTheCake.Server.HTTP
{
    using Common;
    using Contracts;

    public class HttpContext : IHttpContext
    {
        private readonly HttpRequest request;

        public HttpContext(string requestStr)
        {
            CoreValidator.ThrowIfNull(requestStr, nameof(requestStr));

            this.request = new HttpRequest(requestStr);
        }

        public HttpRequest Request => this.request;
    }
}