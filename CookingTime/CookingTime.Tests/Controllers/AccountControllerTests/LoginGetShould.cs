using CookingTime.Authentication.Contracts;
using CookingTime.Factories;
using CookingTime.Web.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace CookingTime.Tests.Controllers.AccountControllerTests
{
    [TestFixture]
    public class LoginGetShould
    {
        [Test]
        public void CallAuthProviderIsAuthenticated()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IUserFactory>();

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Login("test");

            // Assert
            mockedProvider.Verify(p => p.IsAuthenticated, Times.Once);
        }

        [Test]
        public void ReturnDefaultView_WhenUserIsNotAuthenticated()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(x => x.IsAuthenticated).Returns(false);
            var mockedFactory = new Mock<IUserFactory>();

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Login("test"))
                .ShouldRenderDefaultView();
        }

        [Test]
        public void RedirectToHome_WhenUserIsAlreadyAuthenticated()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(x => x.IsAuthenticated).Returns(true);
            var mockedFactory = new Mock<IUserFactory>();

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Login("test"))
                .ShouldRedirectTo<HomeController>(x => x.Index());
        }

        [Test]
        public void SetViewBagReturnUrl()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IUserFactory>();

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            var result = controller.Login("test") as ViewResult;

            // Assert
            Assert.AreEqual("test", result.ViewBag.ReturnUrl);
        }
    }
}
