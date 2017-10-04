using System;
using System.Web.Mvc;
using CookingTime.Authentication.Contracts;
using CookingTime.Web.Infrastructure.Factories;

namespace CookingTime.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthenticationProvider provider;
        private readonly IViewModelFactory factory;

        public HomeController(IAuthenticationProvider provider, IViewModelFactory factory)
        {
            this.provider = provider ?? throw new ArgumentNullException(nameof(provider));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public ActionResult Index()
        {
            var isAuthenticated = this.provider.IsAuthenticated;

            var model = this.factory.CreateHomeViewModel(isAuthenticated);

            return View(model);
        }
    }
}