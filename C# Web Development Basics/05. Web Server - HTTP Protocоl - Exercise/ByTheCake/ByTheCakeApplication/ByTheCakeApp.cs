namespace ByTheCake.ByTheCakeApplication
{
    using System;
    using Controllers;
    using Server.Contracts;
    using Server.HTTP.Contracts;
    using Server.Routing.Contracts;

    public class ByTheCakeApp : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            Func<IHttpContext, IHttpResponse> myFunc = req => new HomeController().Index();
            appRouteConfig
                .Get("/", req => new HomeController().Index());

            appRouteConfig
                .Get("/about", req => new HomeController().About());

            appRouteConfig
                .Get("/add", req => new CakesController().Add());

            appRouteConfig
                .Post("/add", req => new CakesController().Add(req.Request.FormData["name"], req.Request.FormData["price"]));

            appRouteConfig
                .Get("/search", req => new CakesController().Search(req.Request.QuearyParameters));
        }
    }
}