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
    public class GetByIdShould
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
            var guid = Guid.NewGuid();
            
            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);
            
            // Act
            service.GetById(guid);

            // Assert
            mockedRepository.Verify(r => r.GetById(guid), Times.Once);
        }

        [Test]
        public void ReturnCorrectData()
        {
            // Arrange
            var mockedRecipe = new Mock<Recipe>();

            var mockedRepository = new Mock<IRepository<Recipe>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(mockedRecipe.Object);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();
            var guid = Guid.NewGuid();

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            var result = service.GetById(guid);

            // Assert
            Assert.AreSame(mockedRecipe.Object, result);
        }
    }
}
