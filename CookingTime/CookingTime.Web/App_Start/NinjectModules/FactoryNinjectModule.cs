using CookingTime.Factories;
using CookingTime.Web.Infrastructure.Factories;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace CookingTime.Web.App_Start.NinjectModules
{
    public class FactoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUserFactory>().ToFactory().InSingletonScope();
            this.Bind<IRecipeFactory>().ToFactory().InSingletonScope();
            this.Bind<IIngredientFactory>().ToFactory().InSingletonScope();

            this.Bind<IViewModelFactory>().ToFactory().InSingletonScope();
        }
    }
}