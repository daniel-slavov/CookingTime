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
    public class MakeAdminShould
    {
        [Test]
        public void CallAuthenticationProviderAddToRole()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var userId = Guid.NewGuid().ToString();

            var controller = new AdministrationController(mockedProvider.Object, mockedRecipeService.Object, mockedUserService.Object, mockedFactory.Object);

            // Act
            controller.MakeAdmin(userId);

            // Assert
            mockedProvider.Verify(s => s.AddToRole(userId, "admin"), Times.Once);
        }

        [Test]
        public void ReturnCorrectView()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var userId = Guid.NewGuid().ToString();

            var controller = new AdministrationController(mockedProvider.Object, mockedRecipeService.Object, mockedUserService.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.MakeAdmin(userId))
                .ShouldRedirectTo(c => c.AllUsers(null));
        }
    }
}
