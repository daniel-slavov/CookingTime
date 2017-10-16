using CookingTime.Authentication.Contracts;
using CookingTime.Factories;
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
    public class EditPostShould
    {
        [Test]
        public void ShouldCallRecipeServiceUpdate_WhenModelIsValid()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var viewModel = new RecipeViewModel(guid, "title", "description", "imageYrl");
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedRecipeFactory = new Mock<IRecipeFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new RecipeController(mockedRecipeService.Object, mockedRecipeFactory.Object, mockedViewModelFactory.Object, mockedProvider.Object, mockedGuidProvider.Object);

            // Act
            controller.Edit(viewModel);

            // Assert
            mockedRecipeService.Verify(x => x.Update(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ShouldRedirectToDetails_WhenModelIsValid()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var viewModel = new RecipeViewModel(guid, "title", "description", "imageYrl");
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedRecipeFactory = new Mock<IRecipeFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new RecipeController(mockedRecipeService.Object, mockedRecipeFactory.Object, mockedViewModelFactory.Object, mockedProvider.Object, mockedGuidProvider.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Edit(viewModel))
                .ShouldRedirectTo(x => x.Details(guid));
        }

        [Test]
        public void ShouldRedirectToHome_WhenModelIsNotValid()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedRecipeFactory = new Mock<IRecipeFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new RecipeController(mockedRecipeService.Object, mockedRecipeFactory.Object, mockedViewModelFactory.Object, mockedProvider.Object, mockedGuidProvider.Object);
            controller.ModelState.AddModelError("key", "error");

            // Act, Assert
            controller
                .WithCallTo(c => c.Edit(null))
                .ShouldRedirectTo<HomeController>(x => x.Index());
        }
    }
}
