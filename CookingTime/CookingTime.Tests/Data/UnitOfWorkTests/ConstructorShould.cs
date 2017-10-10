using CookingTime.Data;
using CookingTime.Data.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace CookingTime.Tests.Data.UnitOfWorkTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenDbContextIsNull()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new UnitOfWork(null));
        }

        [Test]
        public void NotThrow_WhenDbContextIsProvided()
        {
            // Arrange
            var mockedDbContext = new Mock<ICookingTimeDbContext>();

            // Act, Assert
            Assert.DoesNotThrow(() => new UnitOfWork(mockedDbContext.Object));
        }

        [Test]
        public void InitializeProperly_WhenProperDbContextIsProvided()
        {
            // Arrange
            var mockedDbContext = new Mock<ICookingTimeDbContext>();

            // Act
            var unitOfWork = new UnitOfWork(mockedDbContext.Object);

            // Assert
            Assert.IsNotNull(unitOfWork);
        }
    }
}
