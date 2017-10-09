using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CookingTime.Web.Areas.Administration.Models
{
    public class UserAdministrationViewModel
    {
        public UserAdministrationViewModel(string id, string username, bool isAdmin)
        {
            this.Id = id;
            this.Username = username;
            this.IsAdmin = isAdmin;
        }

        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Is admin?")]
        public bool IsAdmin { get; set; }
    }
}