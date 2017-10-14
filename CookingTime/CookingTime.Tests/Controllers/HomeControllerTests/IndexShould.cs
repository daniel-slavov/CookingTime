using CookingTime.Authentication.Contracts;
using CookingTime.Web.Controllers;
using CookingTime.Web.Infrastructure.Factories;
using CookingTime.Web.Models.Home;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace CookingTime.Tests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class IndexShould
    {
        [Test]
        public void CallProviderIsAuthenticated()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedProvider = new Mock<IAuthenticationProvider>();

            var controller = new HomeController(mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Index();

            // Assert
            mockedProvider.Verify(p => p.IsAuthenticated, Times.Once);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void CallFactoryCreateCorrectly(bool isAuthenticated)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.IsAuthenticated).Returns(isAuthenticated);

            var controller = new HomeController(mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Index();

            // Assert
            mockedFactory.Verify(f => f.CreateHomeViewModel(isAuthenticated), Times.Once);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ReturnViewWithModel(bool isAuthenticated)
        {
            // Arrange
            var model = new HomeViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateHomeViewModel(It.IsAny<bool>())).Returns(model);

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.IsAuthenticated).Returns(isAuthenticated);

            var controller = new HomeController(mockedProvider.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView()
                .WithModel<HomeViewModel>(m => Assert.AreSame(model, m));
        }
    }
}
