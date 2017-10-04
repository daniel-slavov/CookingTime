using CookingTime.Web.Models.Home;
using CookingTime.Web.Models.Navigation;
using CookingTime.Web.Models.Recipe;

namespace CookingTime.Web.Infrastructure.Factories
{
    public interface IViewModelFactory
    {
        HomeViewModel CreateHomeViewModel(bool isAuthenticated);

        NavigationViewModel CreateNavigationViewModel(string username, bool isAuthenticated, bool isAdmin);

        RecipeViewModel CreateRecipeViewModel();

        RecipeViewModel CreateRecipeViewModel(string title, string description);
    }
}