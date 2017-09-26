using CookingTime.Models;
using System;

namespace CookingTime.Factories
{
    public interface IRecipeFactory
    {
        Recipe CreateRecipe(Guid id, string title, string description, User owner);
    }
}
