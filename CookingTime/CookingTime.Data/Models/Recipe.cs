using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTime.Data.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Ingredients = new HashSet<Ingredient>();
        }

        public Recipe(string title, string description, string imagePath, ICollection<Ingredient> ingredients, User owner) : this()
        {
            this.Title = title;
            this.Description = description;
            this.ImagePath = imagePath;
            this.Owner = owner;
        }

        [Key]
        public int RecipeID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public virtual User Owner { get; set; }
    }
}
