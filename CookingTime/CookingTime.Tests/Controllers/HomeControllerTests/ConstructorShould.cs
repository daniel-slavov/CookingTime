using CookingTime.Authentication.Contracts;
using CookingTime.Web.Controllers;
using CookingTime.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTime.Tests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenProviderIsNull()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new HomeController(null, mockedFactory.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenFactoryIsNull()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new HomeController(mockedProvider.Object, null));
        }

        [Test]
        public void InitalizeProperly_WhenDependenciesAreProvided()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedProvider = new Mock<IAuthenticationProvider>();

            // Act
            var controller = new HomeController(mockedProvider.Object, mockedFactory.Object);

            // Assert
            Assert.IsNotNull(controller);
        }
    }
}
