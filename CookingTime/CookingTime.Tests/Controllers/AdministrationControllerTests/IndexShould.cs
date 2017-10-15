using CookingTime.Authentication.Contracts;
using CookingTime.Services.Contracts;
using CookingTime.Web.Areas.Administration.Controllers;
using CookingTime.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace CookingTime.Tests.Controllers.AdministrationControllerTests
{
    [TestFixture]
    public class IndexShould
    {
        [Test]
        public void ReturnCorrectView()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new AdministrationController(mockedProvider.Object, mockedRecipeService.Object, mockedUserService.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
