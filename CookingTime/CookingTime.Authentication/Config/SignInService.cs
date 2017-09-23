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
    // Configure the application sign-in manager which is used in this application.
    public class SignInService : SignInManager<User, string>
    {
        public SignInService(UserService userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        //public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        //{
        //    return user.GenerateUserIdentityAsync((User)UserManager);
        //}

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            var userManager = (UserService)UserManager;
            return userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        }

        public static SignInService Create(IdentityFactoryOptions<SignInService> options, IOwinContext context)
        {
            return new SignInService(context.GetUserManager<UserService>(), context.Authentication);
        }
    }
}
