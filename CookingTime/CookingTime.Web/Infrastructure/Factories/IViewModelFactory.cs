using System;
using CloudinaryDotNet;
using CookingTime.Models;
using CookingTime.Web.Models.Home;
using CookingTime.Web.Models.Navigation;
using PagedList;
using System.Collections.Generic;
using CookingTime.Web.Areas.Users.Models;

namespace CookingTime.Web.Infrastructure.Factories
{
    public interface IViewModelFactory
    {
        HomeViewModel CreateHomeViewModel(bool isAuthenticated);

        NavigationViewModel CreateNavigationViewModel(string username, bool isAuthenticated, bool isAdmin);

        UserIdViewModel CreateUserIdViewModel(string userId);
    }
}