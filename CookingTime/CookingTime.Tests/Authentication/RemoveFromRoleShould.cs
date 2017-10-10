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
    public class RemoveFromRoleShould
    {
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", "admin")]
        public void CallUserManagerRemoveFromRole(string userId, string role)
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedUserStore = new Mock<IUserStore<User>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedUserStore.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.GetUserManager<ApplicationUserManager>()).Returns(mockedUserManager.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.RemoveFromRole(userId, role);

            // Assert
            mockedUserManager.Verify(m => m.RemoveFromRoleAsync(userId, role), Times.Once);
        }
    }
}
