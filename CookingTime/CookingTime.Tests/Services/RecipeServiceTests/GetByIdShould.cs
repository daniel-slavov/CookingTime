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
    public class GetByIdShould
    {
        [Test]
        public void CallRepositoryAll()
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
            mockedRepository.Verify(r => r.All, Times.Once);
        }

        [Test]
        public void ReturnCorrectData()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var user = new User();
            var recipe = new Recipe
            {
                Owner = user,
                ID = guid
            };
            var recipes = new List<Recipe> { recipe }.AsQueryable();
            //var mockedRecipe = new Mock<Recipe>();
            
            var mockedRepository = new Mock<IRepository<Recipe>>();
            mockedRepository.Setup(r => r.All).Returns(recipes);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IRecipeFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedUserService = new Mock<IUserService>();

            var service = new RecipeService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object, mockedDateTimeProvider.Object, mockedGuidProvider.Object, mockedUserService.Object);

            // Act
            var result = service.GetById(guid);

            // Assert
            Assert.AreSame(recipe, result);
        }
    }
}
