using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTime.Data.Models
{
    public class Ingredient
    {
        public Ingredient(string name)
        {
            this.Name = name;
        }

        [Key]
        public string Name { get; set; }
    }
}
