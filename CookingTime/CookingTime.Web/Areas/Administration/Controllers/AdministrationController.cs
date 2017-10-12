using CookingTime.Authentication.Contracts;
using CookingTime.Models;
using CookingTime.Providers.Contracts;
using CookingTime.Services.Contracts;
using CookingTime.Web.Areas.Administration.Models;
using CookingTime.Web.Infrastructure.Factories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookingTime.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdministrationController : Controller
    {
        private readonly IAuthenticationProvider AuthenticationProvider;
        private readonly IRecipeService RecipeService;
        private readonly IUserService UserService;
        private readonly IViewModelFactory ViewModelFactory;

        public AdministrationController(
            IAuthenticationProvider authenticationProvider,
            IRecipeService recipeService,
            IUserService userService,
            IViewModelFactory viewModelFactory
            )
        {
            this.AuthenticationProvider = authenticationProvider ?? throw new ArgumentNullException(nameof(authenticationProvider));
            this.RecipeService = recipeService ?? throw new ArgumentNullException(nameof(recipeService));
            this.UserService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.ViewModelFactory = viewModelFactory ?? throw new ArgumentNullException(nameof(viewModelFactory));
        }

        // GET: Administration/Administration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllRecipes(int? page)
        {
            IEnumerable<RecipeAdministrationViewModel> recipes = this.RecipeService.GetAllWithDeleted()
                .Select(x => this.ViewModelFactory.CreateRecipeAdminViewModel(x.ID, x.Title, x.IsDeleted))
                .ToList();

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return this.View(recipes.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            this.RecipeService.Delete(id);

            return this.RedirectToAction("AllRecipes");
        }

        [HttpPost]
        public ActionResult Recover(Guid id)
        {
            this.RecipeService.Recover(id);

            return this.RedirectToAction("AllRecipes");
        }

        public ActionResult AllUsers(int? page)
        {
            IEnumerable<UserAdministrationViewModel> users = this.UserService.GetAll()
                .Select(x => this.ViewModelFactory.CreateUserAdminViewModel(x.Id, x.UserName, this.AuthenticationProvider.IsInRole(x.Id, "admin")))
                .OrderBy(x => x.Username)
                .ToList();

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return this.View(users.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult MakeAdmin(string id)
        {
            this.AuthenticationProvider.AddToRole(id, "admin");

            return this.RedirectToAction("AllUsers");
        }

        [HttpPost]
        public ActionResult RemoveAdmin(string id)
        {
            this.AuthenticationProvider.RemoveFromRole(id, "admin");

            return this.RedirectToAction("AllUsers");
        }
    }
}