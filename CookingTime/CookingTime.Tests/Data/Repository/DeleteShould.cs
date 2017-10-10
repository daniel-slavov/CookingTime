using CookingTime.Data;
using CookingTime.Data.Contracts;
using CookingTime.Tests.Data.Repository.Fakes;
using Moq;
using NUnit.Framework;
using System;

namespace CookingTime.Tests.Data.Repository
{
    [TestFixture]
    public class DeleteShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenDbContextIsNull()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new EntityFrameworkRepository<FakeRepositoryType>(null));
        }

        [Test]
        public void NotThrow_WhenDbContextIsProvided()
        {
            // Arrange
            var mockedDbContext = new Mock<ICookingTimeDbContext>();

            // Act, Assert
            Assert.DoesNotThrow(() => new EntityFrameworkRepository<FakeRepositoryType>(mockedDbContext.Object));
        }

        [Test]
        public void InitializeProperly_WhenProperDbContextIsProvided()
        {
            // Arrange
            var mockedDbContext = new Mock<ICookingTimeDbContext>();

            // Act
            var repository = new EntityFrameworkRepository<FakeRepositoryType>(mockedDbContext.Object);

            // Assert
            Assert.IsNotNull(repository);
        }
    }
}
