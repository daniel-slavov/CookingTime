using CookingTime.Services.Contracts;
using System;
using System.Collections.Generic;
using CookingTime.Models;
using CookingTime.Data.Contracts;
using CookingTime.Factories;
using CookingTime.Providers.Contracts;
using System.Linq;
using System.Data.Entity;

namespace CookingTime.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository<Recipe> RecipeRepository;
        private readonly IUnitOfWork UnitOfWork;
        private readonly IRecipeFactory RecipeFactory;
        private readonly IDateTimeProvider DateTimeProvider;
        private readonly IGuidProvider GuidProvider;
        private readonly IUserService UserService;

        public RecipeService(
            IRepository<Recipe> recipeRepository,
            IUnitOfWork unitOfWork,
            IRecipeFactory recipeFactory,
            IDateTimeProvider dateTimeProvider,
            IGuidProvider guidProvider,
            IUserService userService
            )
        {
            this.RecipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
            this.UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.RecipeFactory = recipeFactory ?? throw new ArgumentNullException(nameof(recipeFactory));
            this.DateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            this.UserService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.GuidProvider = guidProvider ?? throw new ArgumentNullException(nameof(guidProvider));
        }

        public Recipe GetById(Guid id)
        {
            Recipe recipe = this.RecipeRepository.GetById(id);

            return recipe;
        }

        public IEnumerable<Recipe> GetAll()
        {
            IEnumerable<Recipe> recipes = this.RecipeRepository.All
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedOn);

            return recipes;
        }

        public IEnumerable<Recipe> GetAllWithDeleted()
        {
            IEnumerable<Recipe> recipes = this.RecipeRepository.All
                .OrderBy(x => x.Title);

            return recipes;
        }

        public Guid Create(string title, string description, string imageUrl, string userId)
        {
            User user = this.UserService.GetById(userId);
            DateTime currentTime = this.DateTimeProvider.GetCurrentTime();
            Guid guid = this.GuidProvider.CreateGuid();

            Recipe recipe = this.RecipeFactory.CreateRecipe(guid, title, description, imageUrl, currentTime, false, user);

            this.RecipeRepository.Add(recipe);
            this.UnitOfWork.Commit();

            return guid;
        }

        public void Update(Guid id, string title, string description, string imageUrl)
        {
            Recipe recipe = this.RecipeRepository.GetById(id);
            recipe.Title = title;
            recipe.Description = description;

            this.RecipeRepository.Update(recipe);
            this.UnitOfWork.Commit();
        }

        public void Delete(Guid id)
        {
            Recipe recipe = this.RecipeRepository.All
                .Include(x => x.Owner)
                .FirstOrDefault(x => x.ID == id);

            recipe.Owner = this.UserService.GetById(recipe.Owner.Id);
            recipe.IsDeleted = true;

            this.RecipeRepository.Update(recipe);
            this.UnitOfWork.Commit();
        }

        public void Recover(Guid id)
        {
            Recipe recipe = this.RecipeRepository.All
                .Include(x => x.Owner)
                .FirstOrDefault(x => x.ID == id); ;
            recipe.IsDeleted = false;

            this.RecipeRepository.Update(recipe);
            this.UnitOfWork.Commit();
        }
    }
}
