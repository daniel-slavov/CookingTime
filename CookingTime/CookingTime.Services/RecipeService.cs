using CookingTime.Services.Contracts;
using System;
using System.Collections.Generic;
using CookingTime.Models;
using CookingTime.Data.Contracts;
using CookingTime.Factories;
using CookingTime.Providers.Contracts;
using System.Linq;

namespace CookingTime.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository<Recipe> RecipeRepository;
        private readonly IUnitOfWork UnitOfWork;
        private readonly IRecipeFactory RecipeFactory;
        private readonly IDateTimeProvider DateTimeProvider;
        private readonly IUserService UserService;
        private readonly IIngredientService IngredientService;

        public RecipeService(
            IRepository<Recipe> recipeRepository,
            IUnitOfWork unitOfWork,
            IRecipeFactory recipeFactory,
            IDateTimeProvider dateTimeProvider,
            IUserService userService,
            IIngredientService ingredientService
            )
        {
            this.RecipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
            this.UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.RecipeFactory = recipeFactory ?? throw new ArgumentNullException(nameof(recipeFactory));
            this.DateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            this.UserService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.IngredientService = ingredientService ?? throw new ArgumentNullException(nameof(ingredientService));
        }

        public Recipe Create(string title, string description, ICollection<string> inputIngredients, string userId)
        {
            User user = this.UserService.GetUserById(userId);
            DateTime currentTime = this.DateTimeProvider.GetCurrentTime();
            ICollection<Ingredient> ingredients = this.IngredientService.GetAllByName(inputIngredients);

            Recipe recipe = this.RecipeFactory.CreateRecipe(Guid.NewGuid(), title, description, currentTime, false, ingredients, user);

            this.RecipeRepository.Add(recipe);
            this.UnitOfWork.Commit();

            return recipe;
        }

        public Recipe Create(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void Delete(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Recipe GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipe> GetAll()
        {
            IEnumerable<Recipe> recipes = this.RecipeRepository.All
                .OrderByDescending(x => x.CreatedOn)
                .ToList();

            return recipes;
        }

        public void Update(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
