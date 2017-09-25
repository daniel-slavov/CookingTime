using CookingTime.Authentication;
using CookingTime.Authentication.Contracts;
using Ninject.Modules;

namespace CookingTime.Web.App_Start.NinjectModules
{
    public class AuthNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IAuthenticationProvider>().To<AuthenticationProvider>().InSingletonScope();
        }
    }
}