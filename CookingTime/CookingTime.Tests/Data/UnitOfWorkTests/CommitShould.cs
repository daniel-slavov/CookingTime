using CookingTime.Data;
using CookingTime.Data.Contracts;
using Moq;
using NUnit.Framework;

namespace CookingTime.Tests.Data.UnitOfWorkTests
{
    [TestFixture]
    public class CommitShould
    {
        [Test]
        public void CallDbContextSaveChanges()
        {
            // Arrange
            var mockedDbContext = new Mock<ICookingTimeDbContext>();

            var unitOfWork = new UnitOfWork(mockedDbContext.Object);

            // Act
            unitOfWork.Commit();

            // Assert
            mockedDbContext.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}
