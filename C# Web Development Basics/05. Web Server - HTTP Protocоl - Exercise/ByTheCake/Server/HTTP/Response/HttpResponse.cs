namespace ByTheCake.Server.HTTP.Response
{
    using System.Text;
    using Contracts;
    using Enums;

    public abstract class HttpResponse : IHttpResponse
    {
        protected HttpResponse()
        {
            this.HeaderCollection = new HttpHeaderCollection();
        }

        private HttpHeaderCollection HeaderCollection { get; set; }

        public HttpStatusCode StatusCode { get; protected set; }

        private string StatusMessage => this.StatusCode.ToString();

        public void AddHeader(string location, string redirectUrl)
        {
            HttpHeader currentHeader = new HttpHeader(location, redirectUrl);
            this.HeaderCollection.Add(currentHeader);
        }

        public override string ToString()
        {
            StringBuilder response = new StringBuilder();
            int statusCode = (int)this.StatusCode;

            response.AppendLine($"HTTP/1.1 {statusCode} {this.StatusMessage}");
            response.AppendLine($"{this.HeaderCollection.ToString()}");
            response.AppendLine();

            return response.ToString();
        }
    }
}