namespace SimpleMvc.App.Controllers
{
    using BindingModels;
    using Domain.Data;
    using Domain.Data.Models;
    using MVC.Framework.Attributes.Methods;
    using MVC.Framework.Contracts;
    using MVC.Framework.Controllers;

    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            var user = new User()
            {
                UserName = model.Username,
                Password = model.Password
            };

            using (var db = new SimpleMvcDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            return this.View();
        }
    }
}