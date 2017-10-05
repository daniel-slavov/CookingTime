using CookingTime.Models;
using System;
using System.Collections.Generic;

namespace CookingTime.Factories
{
    public interface IRecipeFactory
    {
        Recipe CreateRecipe(Guid id, string title, string description, string imageUrl, DateTime createdOn, bool isDeleted, User owner);
    }
}
