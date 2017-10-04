using CookingTime.Models;
using System;
using System.Collections.Generic;

namespace CookingTime.Services.Contracts
{
    public interface IRecipeService
    {
        Recipe GetById(Guid id);

        IEnumerable<Recipe> GetAll();

        Recipe Create(string title, string description, ICollection<string> inputIngredients, string userId);

        void Update(Recipe recipe);

        void Delete(Recipe recipe);
    }
}
