using CookingTime.Data;
using CookingTime.Data.Contracts;
using CookingTime.Tests.Data.Repository.Fakes;
using Moq;
using NUnit.Framework;

namespace CookingTime.Tests.Data.Repository
{
    [TestFixture]
    public class UpdateShould
    {
        [Test]
        public void CallDbContextSetUpdated()
        {
            // Arrange
            var mockedDbContext = new Mock<ICookingTimeDbContext>();

            var repository = new EntityFrameworkRepository<FakeRepositoryType>(mockedDbContext.Object);

            var entity = new Mock<FakeRepositoryType>();

            // Act
            repository.Update(entity.Object);

            // Assert
            mockedDbContext.Verify(c => c.SetUpdated(entity.Object), Times.Once);
        }
    }
}
