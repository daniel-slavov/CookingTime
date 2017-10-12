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
    public class CreateShould
    {
        [Test]
        public void CallUserserviceGetById()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Recipe>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            service.Create("title", "description", "imageUrl", "userId");

            // Assert
            mockedUserService.Verify(r => r.GetById("userId"), Times.Once);
        }

        [Test]
        public void CallDateTimeProvider()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Recipe>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            service.Create("title", "description", "imageUrl", "userId");

            // Assert
            mockedDateTimeProvider.Verify(r => r.GetCurrentTime(), Times.Once);
        }

        [Test]
        public void CallGuidProvider()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Recipe>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            service.Create("title", "description", "imageUrl", "userId");

            // Assert
            mockedGuidProvider.Verify(r => r.CreateGuid(), Times.Once);
        }

        [Test]
        public void CallRecipeFactory()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Recipe>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();

            var dateTime = DateTime.UtcNow;
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            mockedDateTimeProvider.Setup(p => p.GetCurrentTime()).Returns(dateTime);

            var guid = Guid.NewGuid();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            mockedGuidProvider.Setup(p => p.CreateGuid()).Returns(guid);

            var user = new Mock<User>();
            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(s => s.GetById(It.IsAny<string>())).Returns(user.Object);

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            service.Create("title", "description", "imageUrl", "userId");

            // Assert
            mockedFactory.Verify(f => f.CreateRecipe(guid, "title", "description", "imageUrl", dateTime, false, user.Object), Times.Once);
        }

        [Test]
        public void CallRepositoryAdd()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Recipe>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            var recipe = new Mock<Recipe>();
            var mockedFactory = new Mock<IRecipeFactory>();
            mockedFactory.Setup(f => f.CreateRecipe(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<bool>(), It.IsAny<User>())).Returns(recipe.Object);

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            service.Create("title", "description", "imageUrl", "userId");

            // Assert
            mockedRepository.Verify(r => r.Add(recipe.Object), Times.Once);
        }

        [Test]
        public void CallUnitOfWorkCommit()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Recipe>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            service.Create("title", "description", "imageUrl", "userId");

            // Assert
            mockedUnitOfWork.Verify(r => r.Commit(), Times.Once);
        }

        [Test]
        public void ReturnCorrectData()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Recipe>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFactory = new Mock<IRecipeFactory>();

            var guid = Guid.NewGuid();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            mockedGuidProvider.Setup(f => f.CreateGuid()).Returns(guid);

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            var result = service.Create("title", "description", "imageUrl", "userId");

            // Assert
            Assert.AreEqual(guid, result);
        }
    }
}
