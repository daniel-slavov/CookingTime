using CookingTime.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CookingTime.Web.Models.Recipe
{
    public class RecipeViewModel
    {
        public RecipeViewModel()
        {
            //this.Ingredients = new HashSet<string>();
        }

        public RecipeViewModel(Guid id, string title, string description, string imageUrl) : this()
        {
            this.ID = id;
            this.Title = title;
            this.Description = description;
            this.ImageUrl = imageUrl;
        }

        public Guid ID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        //[Display(Name = "Ingredients")]
        //public ICollection<string> Ingredients { get; set; }
    }
}