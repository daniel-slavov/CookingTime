using CookingTime.Authentication.Contracts;
using CookingTime.Factories;
using CookingTime.Web.Controllers;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace CookingTime.Tests.Controllers.AccountControllerTests
{
    [TestFixture]
    public class RegisterGetShould
    {
        [Test]
        public void ReturnCorrectView()
        {
            // Assert
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IUserFactory>();

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Register())
                .ShouldRenderDefaultView();
        }
    }
}
