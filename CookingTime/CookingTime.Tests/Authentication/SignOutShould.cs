using CookingTime.Authentication;
using CookingTime.Providers.Contracts;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;

namespace CookingTime.Tests.Authentication
{
    [TestFixture]
    public class SignOutShould
    {
        [Test]
        public void CallHttpContextProviderCurrentOwinContext()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedAuthManager = new Mock<IAuthenticationManager>();

            var mockedOwinContext = new Mock<IOwinContext>();
            mockedOwinContext.Setup(c => c.Authentication).Returns(mockedAuthManager.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.CurrentOwinContext).Returns(mockedOwinContext.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.SignOut();

            // Assert
            mockedHttpContextProvider.Verify(p => p.CurrentOwinContext, Times.Once);
        }

        [Test]
        public void CallAuthenticationManagerSignOut()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedAuthManager = new Mock<IAuthenticationManager>();

            var mockedOwinContext = new Mock<IOwinContext>();
            mockedOwinContext.Setup(c => c.Authentication).Returns(mockedAuthManager.Object);

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.CurrentOwinContext).Returns(mockedOwinContext.Object);

            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Act
            provider.SignOut();

            // Assert
            mockedAuthManager.Verify(m => m.SignOut(It.IsAny<string>()), Times.Once);
        }
    }
}
