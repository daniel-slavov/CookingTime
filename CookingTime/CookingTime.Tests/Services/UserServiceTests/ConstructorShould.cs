using CookingTime.Data.Contracts;
using CookingTime.Models;
using CookingTime.Services;
using Moq;
using NUnit.Framework;
using System;

namespace CookingTime.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenRepositoryIsNull()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new UserService(null, mockedUnitOfWork.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<User>>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new UserService(mockedRepository.Object, null));
        }

        [Test]
        public void NotThrow_WhenAllDependanciesAreProvided()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act, Assert
            Assert.DoesNotThrow(() => new UserService(mockedRepository.Object, mockedUnitOfWork.Object));
        }

        [Test]
        public void InitializeProperly_WhenProperDependanciesAreProvided()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act
            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Assert
            Assert.IsNotNull(service);
        }
    }
}
