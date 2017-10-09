using System;
using System.ComponentModel.DataAnnotations;

namespace CookingTime.Web.Areas.Administration.Models
{
    public class RecipeAdministrationViewModel
    {
        public RecipeAdministrationViewModel(Guid id, string title, bool isDeleted)
        {
            this.ID = id;
            this.Title = title;
            this.IsDeleted = isDeleted;
        }

        [Required]
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Is deleted?")]
        public bool IsDeleted { get; set; }
    }
}