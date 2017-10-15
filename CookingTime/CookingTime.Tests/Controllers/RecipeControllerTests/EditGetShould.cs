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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace CookingTime.Tests.Controllers.RecipeControllerTests
{
    [TestFixture]
    public class EditGetShould
    {
        [Test]
        public void CallRecipeServiceGetById()
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
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            mockedRecipeService.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(recipe);
            var mockedRecipeFactory = new Mock<IRecipeFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new RecipeController(mockedRecipeService.Object, mockedRecipeFactory.Object, mockedViewModelFactory.Object, mockedProvider.Object, mockedGuidProvider.Object);

            // Act
            controller.Edit(guid);

            // Assert
            mockedRecipeService.Verify(s => s.GetById(guid), Times.Once);
        }

        [Test]
        public void CallViewmodelFactoryCreateRecipeViewModel()
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
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            mockedRecipeService.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(recipe);
            var mockedRecipeFactory = new Mock<IRecipeFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new RecipeController(mockedRecipeService.Object, mockedRecipeFactory.Object, mockedViewModelFactory.Object, mockedProvider.Object, mockedGuidProvider.Object);

            // Act
            controller.Edit(guid);

            // Assert
            mockedViewModelFactory.Verify(s => s.CreateRecipeViewModel(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ReturnCorrectViewWithModel()
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
            var viewModel = new RecipeViewModel()
            {
                ID = guid,
                Title = "title",
                Description = "description",
                ImageUrl = "imageUrl"
            };
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            mockedRecipeService.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(recipe);
            var mockedRecipeFactory = new Mock<IRecipeFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(f => f.CreateRecipeViewModel(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(viewModel);

            var controller = new RecipeController(mockedRecipeService.Object, mockedRecipeFactory.Object, mockedViewModelFactory.Object, mockedProvider.Object, mockedGuidProvider.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Edit(guid))
                .ShouldRenderDefaultView()
                .WithModel<RecipeViewModel>(m => Assert.AreSame(m, viewModel));
        }
    }
}
