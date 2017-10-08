using System;
using System.Web.Mvc;
using CookingTime.Authentication.Contracts;
using CookingTime.Web.Infrastructure.Factories;

namespace CookingTime.Web.Controllers
{
    public class NavigationController : Controller
    {
        private readonly IAuthenticationProvider authenticationProvider;
        private readonly IViewModelFactory viewModelFactory;

        public NavigationController(IAuthenticationProvider authenticationProvider, IViewModelFactory viewModelFactory)
        {
            this.viewModelFactory = viewModelFactory ?? throw new ArgumentNullException(nameof(viewModelFactory));
            this.authenticationProvider = authenticationProvider ?? throw new ArgumentNullException(nameof(authenticationProvider));
        }

        public ActionResult Index()
        {
            var isAuthenticated = this.authenticationProvider.IsAuthenticated;
            var username = string.Empty;
            var isAdmin = false;

            if (isAuthenticated)
            {
                username = this.authenticationProvider.CurrentUserUsername;
                var userId = this.authenticationProvider.CurrentUserId;

                isAdmin = this.authenticationProvider.IsInRole(userId, "admin");
            }

            var model = this.viewModelFactory.CreateNavigationViewModel(username, isAuthenticated, isAdmin);
            return this.PartialView("Navigation", model);
        }
    }
}
