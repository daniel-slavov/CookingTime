using CookingTime.Data.Contracts;
using CookingTime.Factories;
using CookingTime.Models;
using CookingTime.Providers.Contracts;
using CookingTime.Services;
using CookingTime.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookingTime.Tests.Services.RecipeServiceTests
{
    [TestFixture]
    public class RecoverShould
    {
        [Test]
        public void CallRepositoryAll()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var user = new Mock<User>();
            var recipe = new Recipe { ID = guid, Owner = user.Object };
            var recipes = new List<Recipe> { recipe }.AsQueryable();
            var mockedRepository = new Mock<IRepository<Recipe>>();
            mockedRepository.Setup(r => r.All).Returns(recipes);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            service.Recover(guid);

            // Assert
            mockedRepository.Verify(r => r.All, Times.Once);
        }

        [Test]
        public void CallUserServiceGetById()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var user = new Mock<User>();
            var recipe = new Recipe { ID = guid, Owner = user.Object };
            var recipes = new List<Recipe> { recipe }.AsQueryable();
            var mockedRepository = new Mock<IRepository<Recipe>>();
            mockedRepository.Setup(r => r.All).Returns(recipes);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            service.Recover(guid);

            // Assert
            mockedUserService.Verify(r => r.GetById(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CallRepositoryUpdate()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var user = new Mock<User>();
            var recipe = new Recipe { ID = guid, Owner = user.Object };
            var recipes = new List<Recipe> { recipe }.AsQueryable();
            var mockedRepository = new Mock<IRepository<Recipe>>();
            mockedRepository.Setup(r => r.All).Returns(recipes);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            service.Recover(guid);

            // Assert
            mockedRepository.Verify(r => r.Update(recipe), Times.Once);
        }

        [Test]
        public void CallUnitOfWorkCommit()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var user = new Mock<User>();
            var recipe = new Recipe { ID = guid, Owner = user.Object };
            var recipes = new List<Recipe> { recipe }.AsQueryable();
            var mockedRepository = new Mock<IRepository<Recipe>>();
            mockedRepository.Setup(r => r.All).Returns(recipes);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            service.Recover(guid);

            // Assert
            mockedUnitOfWork.Verify(r => r.Commit(), Times.Once);
        }

        [Test]
        public void ChangeIsDeletedPropertyToFalse()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var user = new Mock<User>();
            var recipe = new Recipe { ID = guid, IsDeleted = true, Owner = user.Object };
            var recipes = new List<Recipe> { recipe }.AsQueryable();
            var mockedRepository = new Mock<IRepository<Recipe>>();
            mockedRepository.Setup(r => r.All).Returns(recipes);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            service.Recover(guid);

            // Assert
            Assert.IsFalse(recipe.IsDeleted);
        }
    }
}
