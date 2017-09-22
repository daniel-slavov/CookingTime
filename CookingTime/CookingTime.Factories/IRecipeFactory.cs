using CookingTime.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTime.Factories
{
    public interface IRecipeFactory
    {
        Recipe CreateRecipe(string title, string description, string imagePath, ICollection<Ingredient> ingredients, User owner);
    }
}
