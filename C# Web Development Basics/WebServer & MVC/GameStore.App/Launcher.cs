namespace GameStore.App
{
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    class Launcher
    {
        public static void Main()
        {
            MvcEngine.Run(new WebServer(1337, new ControllerRouter(), new ResourceRouter()));
        }
    }
}
