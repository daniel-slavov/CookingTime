using CookingTime.Authentication;
using CookingTime.Authentication.Managers;
using CookingTime.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTime.Tests.Authentication.Mocks
{
    public class MockedAuthenticationProvider : AuthenticationProvider
    {
        public MockedAuthenticationProvider(IDateTimeProvider dateTimeProvider, IHttpContextProvider httpContextProvider)
            : base(dateTimeProvider, httpContextProvider)
        {
        }

        public ApplicationSignInManager GetSignInManager()
        {
            return this.SignInManager;
        }

        public ApplicationUserManager GetUserManager()
        {
            return this.UserManager;
        }
    }
}
