using CookingTime.Authentication.Contracts;
using CookingTime.Factories;
using CookingTime.Models;
using CookingTime.Providers.Contracts;
using CookingTime.Services.Contracts;
using CookingTime.Web.Controllers;
using CookingTime.Web.Infrastructure.Factories;
using CookingTime.Web.Models.Recipe;
using Moq;
using NUnit.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace CookingTime.Tests.Controllers.RecipeControllerTests
{
    [TestFixture]
    public class SearchShould
    {
        [TestCase(null)]
        [TestCase("TITLE")]
        public void CallRecipeServiceGetAll(string pattern)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedRecipeFactory = new Mock<IRecipeFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new RecipeController(mockedRecipeService.Object, mockedRecipeFactory.Object, mockedViewModelFactory.Object, mockedProvider.Object, mockedGuidProvider.Object);

            // Act
            controller.Search(pattern);

            // Assert
            mockedRecipeService.Verify(s => s.GetAll(), Times.Once);
        }

        [TestCase(null)]
        [TestCase("TITLE")]
        public void CallModelFactoryCreateRecipeViewModel(string pattern)
        {
            // Arrange
            var guid = Guid.NewGuid();
            var recipe = new Recipe()
            {
                ID = guid,
                Title = "title",
                Description = "description",
                ImageUrl = "imageUrl"
            };
            var recipes = new List<Recipe> { recipe }.AsEnumerable();
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            mockedRecipeService.Setup(x => x.GetAll()).Returns(recipes);
            var mockedRecipeFactory = new Mock<IRecipeFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new RecipeController(mockedRecipeService.Object, mockedRecipeFactory.Object, mockedViewModelFactory.Object, mockedProvider.Object, mockedGuidProvider.Object);

            // Act
            controller.Search(pattern);

            // Assert
            mockedViewModelFactory.Verify(s => s.CreateRecipeViewModel(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [TestCase(null)]
        [TestCase("TITLE")]
        public void ReturnCorrectViewWithModel(string pattern)
        {
            // Arrange
            var guid = Guid.NewGuid();
            var recipe = new Recipe()
            {
                Title = "title"
            };
            var viewModel = new RecipeViewModel()
            {
                ID = guid,
                Title = "title",
                Description = "description",
                ImageUrl = "imageUrl"
            };
            var recipes = new List<Recipe> { recipe }.AsEnumerable();
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            mockedRecipeService.Setup(x => x.GetAll()).Returns(recipes);
            var mockedRecipeFactory = new Mock<IRecipeFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(f => f.CreateRecipeViewModel(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(viewModel);

            var controller = new RecipeController(mockedRecipeService.Object, mockedRecipeFactory.Object, mockedViewModelFactory.Object, mockedProvider.Object, mockedGuidProvider.Object);

            // Act
            controller.Search(pattern);

            // Assert
            controller
                .WithCallTo(c => c.Search(pattern))
                .ShouldRenderPartialView("_RecipesPartial")
                .WithModel<List<RecipeViewModel>>(m =>
                {
                    Assert.AreEqual(m.Count, 1);
                    Assert.AreSame(m[0], viewModel);
                }
                );
        }
    }
}
