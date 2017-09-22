using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace CookingTime.Models.ManageViewModels
{
    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }
}