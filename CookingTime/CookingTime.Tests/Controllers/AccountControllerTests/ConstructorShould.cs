using CookingTime.Authentication.Contracts;
using CookingTime.Factories;
using CookingTime.Web.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTime.Tests.Controllers.AccountControllerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenProviderNull()
        {
            // Arrange
            var mockedFactory = new Mock<IUserFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new AccountController(null, mockedFactory.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenFactoryNull()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new AccountController(mockedProvider.Object, null));
        }

        [Test]
        public void NotThrow_WhenAllDependenciesAreProvided()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IUserFactory>();

            // Act, Assert
            Assert.DoesNotThrow(() => new AccountController(mockedProvider.Object, mockedFactory.Object));
        }

        [Test]
        public void InitializeProperly_WhenProperDependenciesAreProvided()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IUserFactory>();

            // Act
            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Assert
            Assert.IsNotNull(controller);
        }
    }
}
