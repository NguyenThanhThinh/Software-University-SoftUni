namespace ByTheCake
{
    using ByTheCakeApplication;
    using Server;
    using Server.Contracts;
    using Server.Routing;
    using Server.Routing.Contracts;

    public class Launcher : IRunnable
    {
        private WebServer webserver;

        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            IApplication app = new ByTheCakeApp();
            IAppRouteConfig routeConfig = new AppRouteConfig();
            app.Configure(routeConfig);

            this.webserver = new WebServer(8230, routeConfig);
            this.webserver.Run();
        }
    }
}