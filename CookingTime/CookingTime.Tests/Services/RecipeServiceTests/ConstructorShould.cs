using CookingTime.Data.Contracts;
using CookingTime.Factories;
using CookingTime.Models;
using CookingTime.Providers.Contracts;
using CookingTime.Services;
using CookingTime.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace CookingTime.Tests.Services.RecipeServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenRepositoryIsNull()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new RecipeService(null, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Recipe>>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new RecipeService(mockedRepository.Object, null, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenRecipeFactoryIsNull()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Recipe>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, null, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenDateTimeProviderIsNull()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Recipe>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, null, mockedGuidProvider.Object, mockedUserService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenGuidProviderIsNull()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Recipe>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, null, mockedUserService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserServiceIsNull()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Recipe>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, null));
        }

        [Test]
        public void NotThrow_WhenAllDependenciesAreProvided()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Recipe>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            // Act, Assert
            Assert.DoesNotThrow(() => new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object));
        }

        [Test]
        public void InitializeProperly_WhenProperDependanciesAreProvided()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Recipe>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            // Act
            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Assert
            Assert.IsNotNull(service);
        }
    }
}
