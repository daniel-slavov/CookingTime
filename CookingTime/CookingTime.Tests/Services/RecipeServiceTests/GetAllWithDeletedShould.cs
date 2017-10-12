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
using System.Text;
using System.Threading.Tasks;

namespace CookingTime.Tests.Services.RecipeServiceTests
{
    [TestFixture]
    class GetAllWithDeletedShould
    {
        [Test]
        public void CallRepositoryGetById()
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
            service.GetAll();

            // Assert
            mockedRepository.Verify(r => r.All, Times.Once);
        }

        [Test]
        public void ReturnCorrectData()
        {
            // Arrange
            var recipes = new List<Recipe> { new Recipe() }
                .AsQueryable();

            var mockedRepository = new Mock<IRepository<Recipe>>();
            mockedRepository.Setup(r => r.All).Returns(recipes);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            var result = service.GetAll();

            // Assert
            Assert.AreEqual(recipes, result);
        }
    }
}
