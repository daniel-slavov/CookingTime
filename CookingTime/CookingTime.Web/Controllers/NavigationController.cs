using System;
using System.Web.Mvc;
using CookingTime.Authentication.Contracts;
using CookingTime.Common;
using CookingTime.Web.Infrastructure.Factories;

namespace CookingTime.Web.Controllers
{
    public class NavigationController : Controller
    {
        private readonly IAuthenticationProvider authenticationProvider;
        private readonly IViewModelFactory viewModelFactory;

        public NavigationController(IAuthenticationProvider authenticationProvider, IViewModelFactory viewModelFactory)
        {
            if (authenticationProvider == null)
            {
                throw new ArgumentNullException(nameof(authenticationProvider));
            }

            if (viewModelFactory == null)
            {
                throw new ArgumentNullException(nameof(viewModelFactory));
            }

            this.viewModelFactory = viewModelFactory;
            this.authenticationProvider = authenticationProvider;
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

                isAdmin = this.authenticationProvider.IsInRole(userId, Constants.AdministratorRoleName);
            }

            var model = this.viewModelFactory.CreateNavigationViewModel(username, isAuthenticated, isAdmin);
            return this.PartialView("Navigation", model);
        }
    }
}
