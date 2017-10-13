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
    public class UpdateShould
    {
        [Test]
        public void CallRepositoryGetById()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var recipe = new Recipe
            {
                ID = guid,
                Title = "t",
                Description = "d",
                ImageUrl = "i"
            };
            var mockedRepository = new Mock<IRepository<Recipe>>();
            mockedRepository.Setup(r => r.GetById(guid)).Returns(recipe);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            service.Update(guid, "title", "description", "imageUrl");

            // Assert
            mockedRepository.Verify(r => r.GetById(guid), Times.Once);
        }

        [Test]
        public void CallRepositoryUpdate()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var recipe = new Recipe
            {
                ID = guid,
                Title = "t",
                Description = "d",
                ImageUrl = "i"
            };
            var mockedRepository = new Mock<IRepository<Recipe>>();
            mockedRepository.Setup(r => r.GetById(guid)).Returns(recipe);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            service.Update(guid, "title", "description", "imageUrl");

            // Assert
            mockedRepository.Verify(r => r.Update(recipe), Times.Once);
        }

        [Test]
        public void CallUnitOfWorkCommit()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var recipe = new Recipe
            {
                ID = guid,
                Title = "t",
                Description = "d",
                ImageUrl = "i"
            };
            var mockedRepository = new Mock<IRepository<Recipe>>();
            mockedRepository.Setup(r => r.GetById(guid)).Returns(recipe);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            service.Update(guid, "title", "description", "imageUrl");

            // Assert
            mockedUnitOfWork.Verify(r => r.Commit(), Times.Once);
        }

        [Test]
        public void ChangeProperties()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var recipe = new Recipe
            {
                ID = guid,
                Title = "t",
                Description = "d",
                ImageUrl = "i"
            };
            var mockedRepository = new Mock<IRepository<Recipe>>();
            mockedRepository.Setup(r => r.GetById(guid)).Returns(recipe);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            service.Update(guid, "title", "description", "imageUrl");

            // Assert
            Assert.AreEqual(recipe.Title, "title");
            Assert.AreEqual(recipe.Description, "description");
            Assert.AreEqual(recipe.ImageUrl, "imageUrl");
        }
    }
}
