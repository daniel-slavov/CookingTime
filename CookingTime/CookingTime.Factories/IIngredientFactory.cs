using CookingTime.Models;
using System;

namespace CookingTime.Factories
{
    public interface IIngredientFactory
    {
        Ingredient CreateIngredient(Guid id, string name);
    }
}
