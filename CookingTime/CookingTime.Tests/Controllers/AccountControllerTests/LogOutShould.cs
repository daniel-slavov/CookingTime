using CookingTime.Authentication.Contracts;
using CookingTime.Factories;
using CookingTime.Web.Controllers;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace CookingTime.Tests.Controllers.AccountControllerTests
{
    [TestFixture]
    public class LogOutShould
    {
        [Test]
        public void CallProviderSignOut()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IUserFactory>();

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.LogOut();

            // Assert
            mockedProvider.Verify(p => p.SignOut(), Times.Once);
        }

        [Test]
        public void ReturnRedirectToAction()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IUserFactory>();

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.LogOut())
                .ShouldRedirectTo<HomeController>(c => c.Index());
        }
    }
}
