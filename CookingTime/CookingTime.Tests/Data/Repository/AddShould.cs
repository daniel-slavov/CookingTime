using CookingTime.Data;
using CookingTime.Data.Contracts;
using CookingTime.Tests.Data.Repository.Fakes;
using Moq;
using NUnit.Framework;

namespace CookingTime.Tests.Data.Repository
{
    [TestFixture]
    public class AddShould
    {
        [Test]
        public void CallDbContextSetAdded()
        {
            // Arrange
            var mockedDbContext = new Mock<ICookingTimeDbContext>();

            var repository = new EntityFrameworkRepository<FakeRepositoryType>(mockedDbContext.Object);

            var entity = new Mock<FakeRepositoryType>();

            // Act
            repository.Add(entity.Object);

            // Assert
            mockedDbContext.Verify(c => c.SetAdded(entity.Object), Times.Once);
        }
    }
}
