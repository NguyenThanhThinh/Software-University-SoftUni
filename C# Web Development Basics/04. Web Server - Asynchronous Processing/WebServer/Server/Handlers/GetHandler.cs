namespace WebServer.Server.Handlers
{
    using System;
    using HTTP.Contracts;

    internal class GetHandler : RequestHandler
    {
        public GetHandler(Func<IHttpContext, IHttpResponse> handlingFunc)
            : base(handlingFunc)
        {
        }
    }
}