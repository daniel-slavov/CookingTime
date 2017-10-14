using CookingTime.Authentication.Contracts;
using CookingTime.Web.Controllers;
using CookingTime.Web.Infrastructure.Factories;
using CookingTime.Web.Models.Navigation;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace CookingTime.Tests.Controllers.NavigationControllerTests
{
    [TestFixture]
    public class IndexShould
    {
        [Test]
        public void CallAuthProviderIsAuthenticated()
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new NavigationController(mockedAuthProvider.Object, mockedViewModelFactory.Object);

            // Act
            controller.Index();

            // Assert
            mockedAuthProvider.Verify(p => p.IsAuthenticated, Times.Once);
        }

        [Test]
        public void NotCallAuthProviderCurrentUserId_WhenAuthProviderIsAuthenticatedReturnsFalse()
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new NavigationController(mockedAuthProvider.Object, mockedViewModelFactory.Object);

            // Act
            controller.Index();

            // Assert
            mockedAuthProvider.Verify(p => p.CurrentUserId, Times.Never);
        }

        [Test]
        public void CallFactoryCreateCorrectly_WhenAuthProviderIsAuthenticatedReturnsFalse()
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new NavigationController(mockedAuthProvider.Object, mockedViewModelFactory.Object);

            var expectedIsAuthenticated = false;
            var expectedIsAdmin = false;
            var expectedUsername = string.Empty;

            // Act
            controller.Index();

            // Assert
            mockedViewModelFactory.Verify(f => f.CreateNavigationViewModel(expectedUsername, expectedIsAuthenticated, expectedIsAdmin), Times.Once);
        }

        [Test]
        public void CallAuthProviderCurrentUserId_WhenAuthProviderIsAuthenticatedReturnsTrue()
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();
            mockedAuthProvider.Setup(p => p.IsAuthenticated).Returns(true);

            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new NavigationController(mockedAuthProvider.Object, mockedViewModelFactory.Object);

            // Act
            controller.Index();

            // Assert
            mockedAuthProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [Test]
        public void CallAuthProviderCurrentUserUsername_WhenAuthProviderIsAuthenticatedReturnsTrue()
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();
            mockedAuthProvider.Setup(p => p.IsAuthenticated).Returns(true);

            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new NavigationController(mockedAuthProvider.Object, mockedViewModelFactory.Object);

            // Act
            controller.Index();

            // Assert
            mockedAuthProvider.Verify(p => p.CurrentUserUsername, Times.Once);
        }

        [Test]
        public void CallAuthProviderIsInRoleCorrectly_WhenAuthProviderIsAuthenticatedReturnsTrue(string userId)
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();
            mockedAuthProvider.Setup(p => p.CurrentUserId).Returns(Guid.NewGuid().ToString());
            mockedAuthProvider.Setup(p => p.IsAuthenticated).Returns(true);

            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new NavigationController(mockedAuthProvider.Object, mockedViewModelFactory.Object);

            // Act
            controller.Index();

            // Assert
            mockedAuthProvider.Verify(p => p.IsInRole(userId, It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void SetCorrectViewModel()
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();

            var model = new NavigationViewModel();

            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(
                    f => f.CreateNavigationViewModel(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .Returns(model);

            var controller = new NavigationController(mockedAuthProvider.Object, mockedViewModelFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Index())
                .ShouldRenderPartialView("Navigation")
                .WithModel<NavigationViewModel>(m => Assert.AreSame(model, m));
        }
    }
}
