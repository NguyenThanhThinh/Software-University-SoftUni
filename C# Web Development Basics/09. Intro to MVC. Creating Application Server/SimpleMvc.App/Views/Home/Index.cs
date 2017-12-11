namespace SimpleMvc.App.Views.Home
{
    using MVC.Framework.Contracts;

    public class Index : IRenderable
    {
        public string Render()
        {
            return "<h3>Hello MVC!</h3>";
        }
    }
}