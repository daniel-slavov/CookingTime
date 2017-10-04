using CookingTime.Authentication.Contracts;
using CookingTime.Factories;
using CookingTime.Models;
using CookingTime.Services.Contracts;
using CookingTime.Web.Infrastructure.Factories;
using CookingTime.Web.Models.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookingTime.Web.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService RecipeService;
        private readonly IRecipeFactory RecipeFactory;
        private readonly IViewModelFactory ViewModelFactory;
        private readonly IAuthenticationProvider AuthenticationProvider;

        public RecipeController(
            IRecipeService recipeService,
            IRecipeFactory recipeFactory,
            IViewModelFactory viewModelFactory,
            IAuthenticationProvider authenticationProvider
            )
        {
            this.RecipeService = recipeService ?? throw new ArgumentNullException(nameof(recipeService));
            this.RecipeFactory = recipeFactory ?? throw new ArgumentNullException(nameof(recipeFactory));
            this.ViewModelFactory = viewModelFactory ?? throw new ArgumentNullException(nameof(viewModelFactory));
            this.AuthenticationProvider = authenticationProvider ?? throw new ArgumentNullException(nameof(authenticationProvider));
        }

        // GET: /Recipes/All
        public ActionResult All()
        {
            var dummyModel = new List<RecipeViewModel>();
            return this.View(dummyModel);
        }

        // GET: /Recipes/GetByID/
        public ActionResult Details(string id)
        {
            var dummyModel = this.ViewModelFactory.CreateRecipeViewModel("test", "test");
            

            return this.View(dummyModel);
        }

        // GET: /Recipes/Create
        [Authorize]
        public ActionResult Create()
        {
            RecipeViewModel model = this.ViewModelFactory.CreateRecipeViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(RecipeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = this.AuthenticationProvider.CurrentUserId;
                Recipe recipe = this.RecipeService.Create(model.Title, model.Description, model.Ingredients, userId);

                return this.RedirectToAction("Details", new { id = recipe.ID });
            }
            else
            {
                // should be fixed
                return this.RedirectToAction("All");
            }

        }
    }
}