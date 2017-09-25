using CookingTime.Providers;
using CookingTime.Providers.Contracts;
using Ninject.Modules;

namespace CookingTime.Web.App_Start.NinjectModules
{
    public class ProvidersNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDateTimeProvider>().To<DateTimeProvider>().InSingletonScope();
            this.Bind<IHttpContextProvider>().To<HttpContextProvider>().InSingletonScope();
            this.Bind<ICachingProvider>().To<CachingProvider>().InSingletonScope();
        }
    }
}