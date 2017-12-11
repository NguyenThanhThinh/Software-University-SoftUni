namespace SimpleMvc.App.Controllers
{
    using MVC.Framework.Attributes.Methods;
    using MVC.Framework.Contracts;
    using MVC.Framework.Controllers;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            return this.View();
        }
    }
}