using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using CookingTime.Models.AccountViewModels;
using CookingTime.Models.IdentityModels;
using CookingTime.Models.ManageViewModels;
using CookingTime.Data;
using CookingTime.Data.Models;

namespace CookingTime.Authentication.Config
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class UserService : UserManager<User>
    {
        public UserService(IUserStore<User> store)
            : base(store)
        {
        }

        public static UserService Create(IdentityFactoryOptions<UserService> options, IOwinContext context)
        {
            var manager = new UserService(new UserStore<User>(context.Get<CookingTimeDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            return manager;
        }
    }
}
