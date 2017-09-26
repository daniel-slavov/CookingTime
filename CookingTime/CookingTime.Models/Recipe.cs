using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CookingTime.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Ingredients = new HashSet<Ingredient>();
        }

        public Recipe(Guid id, string title, string description, User owner) : this()
        {
            this.ID = id;
            this.Title = title;
            this.Description = description;
            this.Owner = owner;
        }

        [Key]
        public Guid ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        [Required]
        public virtual User Owner { get; set; }
    }
}
