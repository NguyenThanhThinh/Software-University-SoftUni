namespace Calculator
{
    using ByTheCake;
    using ByTheCake.Server.Routing;
    using ByTheCake.Server.Routing.Contracts;
    using Controllers;

    public class Startup
    {
        public static void Main()
        {
            IAppRouteConfig appConfig = new AppRouteConfig();
            Configure(appConfig);

            var launcher = new Launcher();
            launcher.Run();
        }

        public static void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig
                .Get("/calculator", req => new CalculatorController().Calculate());

            appRouteConfig
                .Post("/calculator",
                req => new CalculatorController()
                    .Calculate(req.Request.FormData["firstNumber"],
                               req.Request.FormData["sign"],
                               req.Request.FormData["secondNumber"]));
        }
    }
}