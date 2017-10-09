using CookingTime.Services;
using CookingTime.Web.Infrastructure.Interception;
using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;

namespace CookingTime.Web.App_Start.NinjectModules
{
    public class InterceptionNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<CachingInterceptor>().ToSelf().InSingletonScope();

            this.AddInterceptions();
        }

        private void AddInterceptions()
        {
            var cachingInterceptor = this.Kernel.Get<CachingInterceptor>();

            Kernel.AddMethodInterceptor(typeof(RecipeService).GetMethod("GetAll"), cachingInterceptor.Intercept);
            Kernel.AddMethodInterceptor(typeof(RecipeService).GetMethod("GetAllWithDeleted"), cachingInterceptor.Intercept);
        }
    }
}