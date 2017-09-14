using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebNumberSUm.Startup))]
namespace WebNumberSUm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
