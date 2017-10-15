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
    public class AllShould
    {
        [TestCase(null)]
        [TestCase(1)]
        public void CallRecipeServiceGetAll(int? page)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedRecipeFactory = new Mock<IRecipeFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            
            var controller = new RecipeController(mockedRecipeService.Object, mockedRecipeFactory.Object, mockedViewModelFactory.Object, mockedProvider.Object, mockedGuidProvider.Object);

            // Act
            controller.All(page);

            // Assert
            mockedRecipeService.Verify(s => s.GetAll(), Times.Once);
        }

        [TestCase(null)]
        [TestCase(1)]
        public void CallViewModelFactoryCreateRecipeViewModel(int? page)
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
            var recipes = new List<Recipe> { recipe } .AsEnumerable();
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            mockedRecipeService.Setup(x => x.GetAll()).Returns(recipes);
            var mockedRecipeFactory = new Mock<IRecipeFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new RecipeController(mockedRecipeService.Object, mockedRecipeFactory.Object, mockedViewModelFactory.Object, mockedProvider.Object, mockedGuidProvider.Object);

            // Act
            controller.All(page);

            // Assert
            mockedViewModelFactory.Verify(s => s.CreateRecipeViewModel(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.AtLeastOnce);
        }

        [TestCase(null)]
        [TestCase(1)]
        public void ReturnCorrectViewWithModel(int? page)
        {
            // Arrange
            var guid = Guid.NewGuid();
            var recipe = new Recipe();
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
            controller.All(page);

            // Assert
            controller
                .WithCallTo(c => c.All(page))
                .ShouldRenderDefaultView()
                .WithModel<PagedList<RecipeViewModel>>(m =>
                    {
                        Assert.AreEqual(m.PageSize, 3);
                        Assert.AreEqual(m.PageNumber, 1);
                        Assert.AreEqual(m.Count, 1);
                        Assert.AreSame(m[0], viewModel);
                    }
                );
        }
    }
}
