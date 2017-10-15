using CookingTime.Authentication.Contracts;
using CookingTime.Factories;
using CookingTime.Providers.Contracts;
using CookingTime.Services.Contracts;
using CookingTime.Web.Controllers;
using CookingTime.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using System;

namespace CookingTime.Tests.Controllers.RecipeControllerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void NotThrow_WhenAllDependenciesAreProvided()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedRecipeFactory = new Mock<IRecipeFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            // Act, Assert
            Assert.DoesNotThrow(() => new RecipeController(mockedRecipeService.Object, mockedRecipeFactory.Object, mockedViewModelFactory.Object, mockedProvider.Object, mockedGuidProvider.Object));
        }

        [Test]
        public void InitializeProperly_WhenProperDependenciesAreProvided()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedRecipeFactory = new Mock<IRecipeFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            // Act
            var controller = new RecipeController(mockedRecipeService.Object, mockedRecipeFactory.Object, mockedViewModelFactory.Object, mockedProvider.Object, mockedGuidProvider.Object);

            // Assert
            Assert.NotNull(controller);
        }

        [Test]
        public void ThrowArgumentNullException_WhenAuthenticationProviderIsNull()
        {
            // Arrange
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedRecipeFactory = new Mock<IRecipeFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new RecipeController(mockedRecipeService.Object, mockedRecipeFactory.Object, mockedViewModelFactory.Object, null, mockedGuidProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenGuidProviderIsNull()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedRecipeFactory = new Mock<IRecipeFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new RecipeController(mockedRecipeService.Object, mockedRecipeFactory.Object, mockedViewModelFactory.Object, mockedProvider.Object, null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenRecipeServiceIsNull()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedRecipeFactory = new Mock<IRecipeFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new RecipeController(null, mockedRecipeFactory.Object, mockedViewModelFactory.Object, mockedProvider.Object, mockedGuidProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenRecipeFactoryIsNull()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new RecipeController(mockedRecipeService.Object, null, mockedViewModelFactory.Object, mockedProvider.Object, mockedGuidProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenViewModelFactoryIsNull()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedRecipeFactory = new Mock<IRecipeFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new RecipeController(mockedRecipeService.Object, mockedRecipeFactory.Object, null, mockedProvider.Object, mockedGuidProvider.Object));
        }


    }
}
