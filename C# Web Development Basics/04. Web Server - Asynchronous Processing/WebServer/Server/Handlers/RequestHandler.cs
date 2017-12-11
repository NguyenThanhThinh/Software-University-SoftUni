namespace WebServer.Server.Handlers
{
    using System;
    using Common;
    using Contracts;
    using HTTP.Contracts;

    public abstract class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpContext, IHttpResponse> handlingFunc;

        protected RequestHandler(Func<IHttpContext, IHttpResponse> handlingFunc)
        {
            CoreValidator.ThrowIfNull(handlingFunc, nameof(handlingFunc));
            this.handlingFunc = handlingFunc;
        }

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            IHttpResponse httpResponse = this.handlingFunc.Invoke(httpContext);

            httpResponse.AddHeader("Content-type", "text/html");

            return httpResponse;
        }
    }
}