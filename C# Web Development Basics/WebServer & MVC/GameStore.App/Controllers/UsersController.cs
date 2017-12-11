namespace GameStore.App.Controllers
{
    using Data;
    using Infrastructior.Common;
    using Models.Users;
    using Services;
    using Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class UsersController : BaseController
    {
        private readonly IUserService userService;

        public UsersController()
        {
            this.userService = new UserService(new GameStoreDbContext());
        }

        public IActionResult Register() => this.View();

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            string email = model.Email;
            string name = model.Fullname;
            string password = model.Password;
            string confirmPassword = model.ConfirmPassword;

            bool passDontMatch = password != confirmPassword;

            if (passDontMatch || !this.IsValidModel(model))
            {
                this.ShowError(ValidationConstants.RegisterError);
                return this.View();
            }

            bool createUser = this.userService.Create(email, password, name);

            if (createUser)
            {
                return this.RedirectToLogin();
            }
            else
            {
                this.ShowError(ValidationConstants.EmailExistsError);
                return this.View();
            }
        }

        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.ShowError(ValidationConstants.LoginError);
                return this.View();
            }

            string email = model.Email;
            string password = model.Password;

            bool userExist = this.userService.UserExists(email, password);

            if (userExist)
            {
                this.SignIn(model.Email);
                return this.RedirectToHome();
            }
            else
            {
                this.ShowError(ValidationConstants.LoginError);
                return this.RedirectToLogin();
            }
        }

        public IActionResult LogOut()
        {
            this.SignOut();
            return this.RedirectToHome();
        }
    }
}