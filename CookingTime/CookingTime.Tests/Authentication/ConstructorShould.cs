using CookingTime.Authentication;
using CookingTime.Providers.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTime.Tests.Authentication
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void InitializeCorrectly()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();

            // Act
            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Assert
            Assert.IsNotNull(provider);
        }

        [Test]
        public void ThrowArgumentNullException_WhenDateTimeProviderIsNull()
        {
            // Arrange
            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new AuthenticationProvider(null, mockedHttpContextProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenHttpContextProviderIsNull()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new AuthenticationProvider(mockedDateTimeProvider.Object, null));
        }
    }
}
