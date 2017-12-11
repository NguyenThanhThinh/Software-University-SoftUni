namespace WebServer.Server.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Contracts;
    using Enums;
    using HTTP.Contracts;
    using HTTP.Response;
    using Routing.Contracts;

    public class HttpHandler : IRequestHandler
    {
        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig serverRouteConfig)
        {
            this.serverRouteConfig = serverRouteConfig;
        }

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            HttpRequestMethod reqestMethod = httpContext.Request.RequestMethod;
            string requestPath = httpContext.Request.Path;
            var registeredRoutes = this.serverRouteConfig.Routes[reqestMethod];

            foreach (KeyValuePair<string, IRoutingContext> registeredRoute in registeredRoutes)
            {
                string routePattern = registeredRoute.Key;
                IRoutingContext routingContext = registeredRoute.Value;

                Regex routeRegex = new Regex(routePattern);
                Match match = routeRegex.Match(requestPath);

                if (!match.Success)
                {
                    continue;
                }

                var parameters = routingContext.Parameters;

                foreach (string parameter in parameters)
                {
                    var parameterValue = match.Groups[parameter].Value;

                    httpContext.Request.AddUrlParameter(parameter, parameterValue);
                }

                return routingContext.RequestHandler.Handle(httpContext);
            }

            return new NotFoundResponse();
        }
    }
}