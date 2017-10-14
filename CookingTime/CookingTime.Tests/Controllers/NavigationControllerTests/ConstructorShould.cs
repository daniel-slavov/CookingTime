using CookingTime.Authentication.Contracts;
using CookingTime.Web.Controllers;
using CookingTime.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using System;

namespace CookingTime.Tests.Controllers.NavigationControllerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void InitializeProperly_WhenAllDependenciesAreProvided()
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            // Act
            var controller = new NavigationController(mockedAuthProvider.Object, mockedViewModelFactory.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void ThrowArgumentNullException_WhenAuthProviderIsNull()
        {
            // Arrange
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            // Act
            Assert.Throws<ArgumentNullException>(() =>
                new NavigationController(null, mockedViewModelFactory.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenViewModelFactoryIsNull()
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();

            // Act
            Assert.Throws<ArgumentNullException>(() =>
                new NavigationController(mockedAuthProvider.Object, null));
        }
    }
}
