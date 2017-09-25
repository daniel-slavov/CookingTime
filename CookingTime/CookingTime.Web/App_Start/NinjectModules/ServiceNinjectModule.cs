using CookingTime.Services;
using CookingTime.Services.Contracts;
using Ninject.Modules;
using Ninject.Web.Common;

namespace CookingTime.Web.App_Start.NinjectModules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUserService>().To<UserService>().InRequestScope();
        }
    }
}