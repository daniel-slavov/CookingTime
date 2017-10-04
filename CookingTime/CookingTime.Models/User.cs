using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace CookingTime.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            
        }

        public User(string username, string email)
           : this()
        {
            this.UserName = username;
            this.Email = email;
        }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
