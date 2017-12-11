namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    using Common;
    using Infrastructure;
    using Server.Http;
    using Server.Http.Contracts;
    using Services;
    using Services.Contracts;

    public class BaseController : Controller
    {
        protected const string HomeIndex = "/";

        private readonly IUserService users;

        public BaseController(IHttpRequest request)
        {
            this.Request = request;
            this.Authentication = new Authentication(false, false);
            this.users = new UserService();
            this.ApplyAuthenticationViewData();
        }

        public IHttpRequest Request { get; private set; }

        protected Authentication Authentication { get; private set; }

        protected override string ApplicationDirectory => "GameStoreApplication";

        public void ApplyAuthenticationViewData()
        {
            string anonymousDisplay = "flex";
            string authDisplay = "none";
            string adminDisplay = "none";

            string autenticatedUserEmail = this.Request
                .Session
                .Get<string>(SessionStore.CurrentUserKey);

            if (autenticatedUserEmail != null)
            {
                anonymousDisplay = "none";
                authDisplay = "flex";
                adminDisplay = "none";

                bool isAdmin = this.users.IsAdmin(autenticatedUserEmail);

                if (isAdmin)
                {
                    adminDisplay = "flex";
                }

                this.Authentication = new Authentication(true, isAdmin);
            }

            this.ViewData["anonymousDisplay"] = anonymousDisplay;
            this.ViewData["authDisplay"] = authDisplay;
            this.ViewData["adminDisplay"] = adminDisplay;
        }
    }
}