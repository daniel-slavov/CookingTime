using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CookingTime.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
