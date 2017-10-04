using CookingTime.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CookingTime.Web.Models.Recipe
{
    public class RecipeViewModel
    {
        public RecipeViewModel()
        {
            this.Ingredients = new HashSet<string>();
        }

        public RecipeViewModel(string title, string description) : this()
        {
            this.Title = title;
            this.Description = description;
        }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Ingredients")]
        public ICollection<string> Ingredients { get; set; }
    }
}