using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTime.Data.Models
{
    public class User
    {
        public User()
        {
            this.Recipes = new HashSet<Recipe>();
        }

        public User(string username, string hashedPassword, ICollection<Recipe> recipes) : this()
        {
            this.Username = username;
            this.HashedPassword = hashedPassword;
            this.Recipes = recipes;
        }

        [Key]
        [Required]
        // [MinLength(6)]
        public string Username { get; set; }

        [Required]
        // [MinLength(6)]
        public string HashedPassword { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
