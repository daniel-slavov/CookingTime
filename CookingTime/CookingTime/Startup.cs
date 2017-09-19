using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CookingTime.Startup))]
namespace CookingTime
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
