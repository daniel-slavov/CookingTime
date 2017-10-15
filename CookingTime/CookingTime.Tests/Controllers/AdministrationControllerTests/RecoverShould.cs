using CookingTime.Authentication.Contracts;
using CookingTime.Services.Contracts;
using CookingTime.Web.Areas.Administration.Controllers;
using CookingTime.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace CookingTime.Tests.Controllers.AdministrationControllerTests
{
    [TestFixture]
    public class RecoverShould
    {
        [Test]
        public void CallRecipeServiceDelete()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var guid = Guid.NewGuid();

            var controller = new AdministrationController(mockedProvider.Object, mockedRecipeService.Object, mockedUserService.Object, mockedFactory.Object);

            // Act
            controller.Recover(guid);

            // Assert
            mockedRecipeService.Verify(s => s.Recover(guid), Times.Once);
        }

        [Test]
        public void ReturnCorrectView()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var guid = Guid.NewGuid();

            var controller = new AdministrationController(mockedProvider.Object, mockedRecipeService.Object, mockedUserService.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Recover(guid))
                .ShouldRedirectTo(c => c.AllRecipes(null));
        }
    }
}
