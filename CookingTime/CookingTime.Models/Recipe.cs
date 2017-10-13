using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CookingTime.Models
{
    public class Recipe
    {
        public Recipe()
        {
            //this.Ingredients = new HashSet<Ingredient>();
        }

        public Recipe(Guid id, string title, string description, string imageUrl, DateTime createdOn, bool isDeleted, User owner) : this()
        {
            this.ID = id;
            this.Title = title;
            this.Description = description;
            this.ImageUrl = imageUrl;
            this.CreatedOn = createdOn;
            this.IsDeleted = IsDeleted;
            //this.Ingredients = ingredients;
            this.Owner = owner;
        }

        [Key]
        public Guid ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        //public ICollection<Ingredient> Ingredients { get; set; }

        //public string UserId { get; set; }

        [Required]
        public User Owner { get; set; }
    }
}
