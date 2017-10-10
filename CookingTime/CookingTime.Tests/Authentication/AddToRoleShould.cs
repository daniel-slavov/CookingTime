using Moq;
using NUnit.Framework;
using CookingTime.Providers.Contracts;
using CookingTime.Models;
using CookingTime.Authentication;
using CookingTime.Authentication.Managers;
using Microsoft.AspNet.Identity;

namespace CookingTime.Tests.Authentication
{
    [TestFixture]
    public class AddToRoleShould
    {
        [Test]
        public void CallUserManager()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.AddToRole("4a1dc234-6cf6-41b6-a65a-45df40a2baf6", "admin");

            // Assert
            mockedUserManager.Verify(m => m.AddToRoleAsync("4a1dc234-6cf6-41b6-a65a-45df40a2baf6", "admin"), Times.Once);
        }
    }
}