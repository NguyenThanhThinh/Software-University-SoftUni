namespace SimpleMvc.App
{
    using MVC.Framework;
    using MVC.Framework.Routers;
    using WebServer;

    public class Launcher
    {
        public static void Main()
        {
            MvcEngine.Run(new WebServer(1337, new ControllerRouter()));
        }
    }
}