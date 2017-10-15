using CookingTime.Authentication.Contracts;
using CookingTime.Services.Contracts;
using CookingTime.Web.Areas.Administration.Controllers;
using CookingTime.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using System;

namespace CookingTime.Tests.Controllers.AdministrationControllerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void NotThrow_WhenAllDependenciesAreProvided()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            // Act, Assert
            Assert.DoesNotThrow(() => new AdministrationController(mockedProvider.Object, mockedRecipeService.Object, mockedUserService.Object, mockedFactory.Object));
        }

        [Test]
        public void InitializeProperly_WhenProperDependenciesAreProvided()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            // Act
            var controller =  new AdministrationController(mockedProvider.Object, mockedRecipeService.Object, mockedUserService.Object, mockedFactory.Object);

            // Assert
            Assert.NotNull(controller);
        }

        [Test]
        public void ThrowArgumentNullException_WhenAuthenticationProviderIsNull()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new AdministrationController(null, mockedRecipeService.Object, mockedUserService.Object, mockedFactory.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenRecipeServiceIsNull()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new AdministrationController(mockedProvider.Object, null, mockedUserService.Object, mockedFactory.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserServiceIsNull()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new AdministrationController(mockedProvider.Object, mockedRecipeService.Object, null, mockedFactory.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenViewModelFactoryIsNull()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedRecipeService = new Mock<IRecipeService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new AdministrationController(mockedProvider.Object, mockedRecipeService.Object, mockedUserService.Object, null));
        }
    }
}
