using CookingTime.Web.Models.Home;
using CookingTime.Web.Models.Navigation;

namespace CookingTime.Web.Infrastructure.Factories
{
    public interface IViewModelFactory
    {
        HomeViewModel CreateHomeViewModel(bool isAuthenticated);

        NavigationViewModel CreateNavigationViewModel(string username, bool isAuthenticated, bool isAdmin);
    }
}