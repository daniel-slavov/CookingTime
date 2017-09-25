using CloudinaryDotNet;
using CookingTime.Factories;
using CookingTime.Web.Infrastructure.Factories;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace CookingTime.Web.App_Start.NinjectModules
{
    public class FactoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUserFactory>().ToFactory().InSingletonScope();

            this.Bind<IViewModelFactory>().ToFactory().InSingletonScope();
            //this.Bind<ICloudinaryFactory>().ToFactory().InSingletonScope();

            //this.Bind<Cloudinary>()
            //    .ToMethod(this.GetCloudinary)
            //    .NamedLikeFactoryMethod((ICloudinaryFactory f) => f.GetCloudinary());
        }

  //      private Cloudinary GetCloudinary(IContext arg)
  //      {
  //          var account = new Account(
  //"cwetanow",
  //"742665798753294",
  //"7dLDYfT_LfNCGI9FPtyEG7G8dm0");

  //          return new Cloudinary(account);
  //      }
    }
}