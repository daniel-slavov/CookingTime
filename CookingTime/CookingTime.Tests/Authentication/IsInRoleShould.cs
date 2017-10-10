using CookingTime.Authentication;
using CookingTime.Authentication.Managers;
using CookingTime.Models;
using CookingTime.Providers.Contracts;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;

namespace CookingTime.Tests.Authentication
{
    [TestFixture]
    public class IsInRoleShould
    {
        [TestCase("4a1dc234-6cf6-41b6-a65a-45df40a2baf6", "admin")]
        public void CallUserManagerIsInRole(string userId, string role)
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.IsInRole(userId, role);

            // Assert
            mockedUserManager.Verify(m => m.IsInRoleAsync(userId, role), Times.Once);
        }
        
        [TestCase("4a1dc234-6cf6-41b6-a65a-45df40a2baf6", "admin", true)]
        [TestCase("4a1dc234-6cf6-41b6-a65a-45df40a2baf6", "admin", false)]
        public void ReturnCorrectResult(string userId, string role, bool isInRole)
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);
            mockedUserManager.Setup(m => m.IsInRoleAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(isInRole);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            var result = provider.IsInRole(userId, role);

            // Assert
            Assert.AreEqual(isInRole, result);
        }

        [Test]
        public void ReturnFalse_WhenUserIdIsNull()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            var result = provider.IsInRole(null, "admin");

            // Assert
            Assert.IsFalse(result);
        }
    }
}
