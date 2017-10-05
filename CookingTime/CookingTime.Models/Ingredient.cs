//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;

//namespace CookingTime.Models
//{
//    public class Ingredient
//    {
//        public Ingredient()
//        {
//            this.Recipes = new HashSet<Recipe>();
//        }

//        public Ingredient(Guid id, string name) : this()
//        {
//            this.ID = id;
//            this.Name = name;
//        }

//        [Key]
//        [Required]
//        public Guid ID { get; set; }

//        [Required]
//        public string Name { get; set; }

//        public virtual ICollection<Recipe> Recipes { get; set; }
//    }
//}
