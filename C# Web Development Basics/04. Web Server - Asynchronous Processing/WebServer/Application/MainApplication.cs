namespace WebServer.Application
{
    using Controllers;
    using Server.Contracts;
    using Server.Handlers;
    using Server.Routing.Contracts;

    public class MainApplication : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.Get("/", request => new HomeController().Index());

            appRouteConfig.AddRoute(
                "/register",
                new PostHandler(
                    request => new UserController()
                    .RegisterPost(request.Request.FormData["name"])));

            appRouteConfig.AddRoute(
                "/register",
                new GetHandler(request => new UserController().RegisterGet()));

            appRouteConfig.AddRoute(
                "/user/{(?<name>[a-z]+)}",
                new GetHandler(request => new UserController()
                .Details(request.Request.UrlParameters["name"])));
        }
    }
}