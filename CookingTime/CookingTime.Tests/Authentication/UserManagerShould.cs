﻿using CookingTime.Authentication.Managers;
using CookingTime.Providers.Contracts;
using CookingTime.Tests.Authentication.Mocks;
using Moq;
using NUnit.Framework;

namespace CookingTime.Tests.Authentication
{
    [TestFixture]
    public class UserManagerShould
    {
        [Test]
        public void CallHttpContextProviderGetUserManager()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();

            var provider = new MockedAuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.GetUserManager();

            // Assert
            mockedHttpContextProvider.Verify(p => p.GetUserManager<ApplicationUserManager>(), Times.Once);
        }
    }
}
