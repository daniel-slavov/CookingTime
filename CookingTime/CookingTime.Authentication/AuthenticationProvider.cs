﻿using System;
using CookingTime.Authentication.Contracts;
using CookingTime.Authentication.Managers;
using CookingTime.Models;
using CookingTime.Providers.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CookingTime.Authentication
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly IHttpContextProvider httpContextProvider;

        public AuthenticationProvider(IDateTimeProvider dateTimeProvider, IHttpContextProvider httpContextProvider)
        {
            this.dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            this.httpContextProvider = httpContextProvider ?? throw new ArgumentNullException(nameof(httpContextProvider));
        }

        protected ApplicationSignInManager SignInManager
        {
            get
            {
                return this.httpContextProvider.GetUserManager<ApplicationSignInManager>();
            }
        }
        protected ApplicationUserManager UserManager
        {
            get
            {
                return this.httpContextProvider.GetUserManager<ApplicationUserManager>();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return this.httpContextProvider.CurrentIdentity.IsAuthenticated;
            }
        }

        public string CurrentUserId
        {
            get
            {
                return this.httpContextProvider.CurrentIdentity.GetUserId();
            }
        }

        public string CurrentUserUsername
        {
            get
            {
                return this.httpContextProvider.CurrentIdentity.GetUserName();
            }
        }

        public IdentityResult RegisterAndLoginUser(User user, string password, bool isPersistent, bool rememberBrowser)
        {
            var result = this.UserManager.Create(user, password);

            if (result.Succeeded)
            {
                this.SignInManager.SignIn(user, isPersistent, rememberBrowser);
            }

            return result;
        }

        public SignInStatus SignInWithPassword(string email, string password, bool rememberMe, bool shouldLockout)
        {
            return this.SignInManager.PasswordSignIn(email, password, rememberMe, shouldLockout);
        }

        public void SignOut()
        {
            this.httpContextProvider.CurrentOwinContext.Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        public bool IsInRole(string userId, string roleName)
        {
            return userId != null && this.UserManager.IsInRole(userId, roleName);
        }

        public IdentityResult AddToRole(string userId, string roleName)
        {
            return this.UserManager.AddToRole(userId, roleName);
        }

        public IdentityResult RemoveFromRole(string userId, string roleName)
        {
            return this.UserManager.RemoveFromRole(userId, roleName);
        }
    }
}
