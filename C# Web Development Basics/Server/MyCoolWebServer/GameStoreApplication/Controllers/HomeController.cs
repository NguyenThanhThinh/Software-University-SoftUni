namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    using Server.Http.Contracts;

    public class HomeController : BaseController
    {
        public IHttpResponse Index() => this.FileViewResponse(@"home\index");

        public HomeController(IHttpRequest request)
            : base(request)
        {
        }
    }
}