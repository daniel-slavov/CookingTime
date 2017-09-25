using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CookingTime.Web.Startup))]
namespace CookingTime.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
