namespace FDMC.Middleware
{
    using System.Threading.Tasks;
    using Infrastructior;
    using Microsoft.AspNetCore.Http;

    public class HttpContextTypeMiddleware
    {
        private readonly RequestDelegate next;

        public HttpContextTypeMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add(HttpHeader.ContentType, "text/html");
            return this.next(context);
        }
    }
}