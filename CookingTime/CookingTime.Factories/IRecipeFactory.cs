using CookingTime.Models;
using System;
using System.Collections.Generic;

namespace CookingTime.Factories
{
    public interface IRecipeFactory
    {
        Recipe CreateRecipe(Guid id, string title, string description, DateTime createdOn, bool isDeleted, ICollection<Ingredient> ingredients, User owner);
    }
}
