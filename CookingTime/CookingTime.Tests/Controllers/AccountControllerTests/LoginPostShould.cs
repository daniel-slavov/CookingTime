using CookingTime.Authentication.Contracts;
using CookingTime.Factories;
using CookingTime.Web.Controllers;
using CookingTime.Web.Models.Account;
using Microsoft.AspNet.Identity.Owin;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace CookingTime.Tests.Controllers.AccountControllerTests
{
    [TestFixture]
    public class LoginPostShould
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

        [TestCase(true)]
        [TestCase(false)]
        public void ReturnViewWithModel_WhenModelStateIsNotValid(bool remember)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            var mockedFactory = new Mock<IUserFactory>();

            var model = new LoginViewModel()
            {
                Username = "username",
                Password = "password",
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);
            controller.ModelState.AddModelError("key", "error");

            // Act, Assert
            controller
                .WithCallTo(c => c.Login(model, ""))
                .ShouldRenderDefaultView()
                .WithModel<LoginViewModel>(m => Assert.AreSame(model, m));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void CallProviderSignInWithPassword_ModelStateIstValid(bool remember)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            var mockedFactory = new Mock<IUserFactory>();

            var model = new LoginViewModel()
            {
                Username = "username",
                Password = "password",
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Login(model, "url");

            // Assert
            mockedProvider.Verify(p => p.SignInWithPassword("username", "password", remember, It.IsAny<bool>()), Times.Once);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ReturnRedirectResultWithCorrectUrl_WhenProviderReturnsSuccess(bool remember)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.SignInWithPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(SignInStatus.Success);

            var mockedFactory = new Mock<IUserFactory>();

            var model = new LoginViewModel()
            {
                Username = "username",
                Password = "password",
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Login(model, "url"))
                .ShouldRedirectTo("url");
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ReturnRedirectResultWithHomeIndex_WhenSuccessReturnUrlIsEmty(bool remember)
        {
            // Arrange
            var expectedUrl = "/Home/Index";

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.SignInWithPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(SignInStatus.Success);

            var mockedFactory = new Mock<IUserFactory>();

            var model = new LoginViewModel()
            {
                Username = "username",
                Password = "password",
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Login(model, null))
                .ShouldRedirectTo(expectedUrl);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ReturnLockoutView_WhenProviderReturnsLockedOut(bool remember)
        {
            // Arrange
            var lockoutViewName = "Lockout";

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.SignInWithPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(SignInStatus.LockedOut);

            var mockedFactory = new Mock<IUserFactory>();

            var model = new LoginViewModel()
            {
                Username = "username",
                Password = "password",
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Login(model, "url"))
                .ShouldRenderView(lockoutViewName);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void AddModelError_WhenProviderReturnsFailure(bool remember)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.SignInWithPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(SignInStatus.Failure);

            var mockedFactory = new Mock<IUserFactory>();

            var model = new LoginViewModel()
            {
                Username = "username",
                Password = "password",
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Login(model, "url");

            // Assert
            Assert.IsFalse(controller.ModelState.IsValid);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestPostLogin_ProviderReturnsFailure_ShouldReturnViewWithModel(bool remember)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.SignInWithPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(SignInStatus.Failure);

            var mockedFactory = new Mock<IUserFactory>();

            var model = new LoginViewModel()
            {
                Username = "username",
                Password = "password",
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Login(model, "url"))
                .ShouldRenderDefaultView()
                .WithModel<LoginViewModel>(m =>
                {
                    Assert.AreSame(model, m);
                });
        }
    }
}
