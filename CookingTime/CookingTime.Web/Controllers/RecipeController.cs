using CookingTime.Authentication.Contracts;
using CookingTime.Factories;
using CookingTime.Models;
using CookingTime.Providers.Contracts;
using CookingTime.Services.Contracts;
using CookingTime.Web.Infrastructure.Factories;
using CookingTime.Web.Models.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace CookingTime.Web.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService RecipeService;
        private readonly IRecipeFactory RecipeFactory;
        private readonly IViewModelFactory ViewModelFactory;
        private readonly IAuthenticationProvider AuthenticationProvider;
        private readonly IGuidProvider GuidProvider;

        public RecipeController(
            IRecipeService recipeService,
            IRecipeFactory recipeFactory,
            IViewModelFactory viewModelFactory,
            IAuthenticationProvider authenticationProvider,
            IGuidProvider guidProvider
            )
        {
            this.RecipeService = recipeService ?? throw new ArgumentNullException(nameof(recipeService));
            this.RecipeFactory = recipeFactory ?? throw new ArgumentNullException(nameof(recipeFactory));
            this.ViewModelFactory = viewModelFactory ?? throw new ArgumentNullException(nameof(viewModelFactory));
            this.AuthenticationProvider = authenticationProvider ?? throw new ArgumentNullException(nameof(authenticationProvider));
            this.GuidProvider = guidProvider ?? throw new ArgumentNullException(nameof(guidProvider));
        }

        // GET: /Recipes/All
        public ActionResult All(int? page)
        {
            IEnumerable<RecipeViewModel> recipes = this.RecipeService.GetAll()
                .Select(x => this.ViewModelFactory.CreateRecipeViewModel(x.ID, x.Title, x.Description, x.ImageUrl))
                .ToList();

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return this.View(recipes.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Recipes/GetByID/
        public ActionResult Details(Guid id)
        {
            Recipe recipe = this.RecipeService.GetById(id);

            RecipeViewModel model = this.ViewModelFactory.CreateRecipeViewModel(recipe.ID, recipe.Title, recipe.Description, recipe.ImageUrl);

            return this.View(model);
        }

        // GET: /Recipes/Create
        [Authorize]
        public ActionResult Create()
        {
            RecipeViewModel model = this.ViewModelFactory.CreateRecipeViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(RecipeViewModel model)
        {
            if (ModelState.IsValid)
            {
                string userId = this.AuthenticationProvider.CurrentUserId;
                Guid id = this.RecipeService.Create(model.Title, model.Description, model.ImageUrl, userId);

                return this.RedirectToAction("Details", new { id = id });
            }
            else
            {
                // should be fixed
                return this.RedirectToAction("All");
            }

        }

        [Authorize]
        public ActionResult Edit(Guid id)
        {
            Recipe recipe = this.RecipeService.GetById(id);
            RecipeViewModel model = this.ViewModelFactory.CreateRecipeViewModel(recipe.ID, recipe.Title, recipe.Description, recipe.ImageUrl);

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(RecipeViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.RecipeService.Update(model.ID, model.Title, model.Description, model.ImageUrl);

                return this.RedirectToAction("Details", new { id = model.ID });
            }
            else
            {
                // To be fixed!
                return this.RedirectToAction("Update", new { id = model.ID });
            }
        }
    }
}