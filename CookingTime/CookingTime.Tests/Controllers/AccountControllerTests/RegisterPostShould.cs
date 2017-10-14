using CookingTime.Authentication.Contracts;
using CookingTime.Factories;
using CookingTime.Models;
using CookingTime.Web.Controllers;
using CookingTime.Web.Models.Account;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace CookingTime.Tests.Controllers.AccountControllerTests
{
    [TestFixture]
    public class RegisterPostShould
    {
        [Test]
        public void CallUserFactoryCreateUserCorrectly_WhenModelStateIsValid()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.RegisterAndLoginUser(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(IdentityResult.Success);

            var mockedFactory = new Mock<IUserFactory>();

            var model = new RegisterViewModel
            {
                Email = "mail@mail.com",
                Username = "username",
                Password = "password"
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Register(model);

            // Assert
            mockedFactory.Verify(f => f.CreateUser("username", "mail@mail.com"), Times.Once);
        }

        [Test]
        public void CallProviderRegisterAndLoginUserCorrectly_WhenModelStateIsValid()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.RegisterAndLoginUser(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(IdentityResult.Success);

            var user = new User();

            var mockedFactory = new Mock<IUserFactory>();
            mockedFactory.Setup(f => f.CreateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(user);

            var model = new RegisterViewModel
            {
                Email = "mail@mail.com",
                Username = "username",
                Password = "password"
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Register(model);

            // Assert
            mockedProvider.Verify(p => p.RegisterAndLoginUser(user, "password", It.IsAny<bool>(), It.IsAny<bool>()));
        }

        [Test]
        public void ReturnRedirectToRouteResult_WhenResultSuccess()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.RegisterAndLoginUser(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(IdentityResult.Success);

            var user = new User();

            var mockedFactory = new Mock<IUserFactory>();
            mockedFactory.Setup(f => f.CreateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(user);

            var model = new RegisterViewModel
            {
                Email = "mail@mail.com",
                Username = "username",
                Password = "password"
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Register(model))
                .ShouldRedirectTo<HomeController>(c => c.Index());
        }

        [Test]
        public void ReturnViewWithModel_WhenResultNotSuccess()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.RegisterAndLoginUser(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(IdentityResult.Failed(null));

            var user = new User();

            var mockedFactory = new Mock<IUserFactory>();
            mockedFactory.Setup(f => f.CreateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(user);

            var model = new RegisterViewModel
            {
                Email = "mail@mail.com",
                Username = "username",
                Password = "password"
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Register(model))
                .ShouldRenderDefaultView()
                .WithModel<RegisterViewModel>(m => Assert.AreSame(model, m));
        }

        [Test]
        public void ReturnViewWithModel_WhenModelStateIsNotValid()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.RegisterAndLoginUser(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(IdentityResult.Success);

            var user = new User();

            var mockedFactory = new Mock<IUserFactory>();
            mockedFactory.Setup(f => f.CreateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(user);

            var model = new RegisterViewModel
            {
                Email = "mail@mail.com",
                Username = "username",
                Password = "password"
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);
            controller.ModelState.AddModelError("key", "message");

            // Act, Assert
            controller
                .WithCallTo(c => c.Register(model))
                .ShouldRenderDefaultView()
                .WithModel<RegisterViewModel>(m => Assert.AreSame(model, m));
        }
    }
}
