namespace WebServer.Server.Routing.Contracts
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using Handlers;
    using HTTP.Contracts;

    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes { get; }

        void Get(string route, Func<IHttpContext, IHttpResponse> handler);

        void Post(string route, Func<IHttpContext, IHttpResponse> handler);

        void AddRoute(string route, RequestHandler httpHandler);
    }
}