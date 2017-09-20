using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CookingTime.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}