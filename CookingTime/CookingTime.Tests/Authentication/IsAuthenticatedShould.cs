using CookingTime.Authentication;
using CookingTime.Providers.Contracts;
using Moq;
using NUnit.Framework;
using System.Security.Principal;

namespace CookingTime.Tests.Authentication
{
    [TestFixture]
    public class IsAuthenticatedShould
    {
        [Test]
        public void CallHttpContextProviderCurrentIdentity()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedIdentity = new Mock<IIdentity>();

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.CurrentIdentity).Returns(mockedIdentity.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            var result = provider.IsAuthenticated;

            // Assert
            mockedHttpContextProvider.Verify(p => p.CurrentIdentity, Times.Once);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ReturnCorrectResult(bool isAuthenticated)
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedIdentity = new Mock<IIdentity>();
            mockedIdentity.Setup(i => i.IsAuthenticated).Returns(isAuthenticated);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.CurrentIdentity).Returns(mockedIdentity.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            var result = provider.IsAuthenticated;

            // Assert
            Assert.AreEqual(isAuthenticated, result);
        }
    }
}
