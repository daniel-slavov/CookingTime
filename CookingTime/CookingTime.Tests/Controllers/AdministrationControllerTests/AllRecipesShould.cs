using CookingTime.Authentication.Contracts;
using CookingTime.Models;
using CookingTime.Services.Contracts;
using CookingTime.Web.Areas.Administration.Controllers;
using CookingTime.Web.Areas.Administration.Models;
using CookingTime.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace CookingTime.Tests.Controllers.AdministrationControllerTests
{
    [TestFixture]
    public class AllRecipesShould
    {
        [TestCase(null)]
        [TestCase(1)]
        public void CallRecipeServiceGetAllWithDeleted(int? page)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new AdministrationController(mockedProvider.Object, mockedRecipeService.Object, mockedUserService.Object, mockedFactory.Object);

            // Act
            controller.AllRecipes(page);

            // Assert
            mockedRecipeService.Verify(s => s.GetAllWithDeleted(), Times.Once);
        }

        [TestCase(null, true)]
        [TestCase(1, true)]
        [TestCase(null, false)]
        [TestCase(1, false)]
        public void ReturnCorrectViewWithModel(int? page, bool isDeleted)
        {
            // Arrange
            var guid = Guid.NewGuid();
            var recipe = new Recipe()
            {
                ID = guid,
                Title = "title",
                IsDeleted = isDeleted
            };
            var viewModel = new RecipeAdministrationViewModel(guid, "title", isDeleted);
            var recipes = new List<Recipe> { recipe } .AsEnumerable();
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedRecipeService = new Mock<IRecipeService>();
            mockedRecipeService.Setup(x => x.GetAllWithDeleted()).Returns(recipes);
            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(x => x.CreateRecipeAdminViewModel(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<bool>())).Returns(viewModel);

            var controller = new AdministrationController(mockedProvider.Object, mockedRecipeService.Object, mockedUserService.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.AllRecipes(page))
                .ShouldRenderDefaultView()
                .WithModel<PagedList<RecipeAdministrationViewModel>>(m =>
                    {
                        Assert.AreEqual(m.PageSize, 10);
                        Assert.AreEqual(m.PageNumber, 1);
                        Assert.AreEqual(m.Count, 1);
                        Assert.AreSame(m[0], viewModel);
                    }
                );
        }
    }
}
