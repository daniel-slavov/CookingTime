using CookingTime.Data;
using CookingTime.Data.Contracts;
using CookingTime.Tests.Data.Repository.Fakes;
using Moq;
using NUnit.Framework;
using System.Data.Entity;

namespace CookingTime.Tests.Data.Repository
{
    [TestFixture]
    public class GetByIdShould
    {
        [Test]
        public void CallDbContextSetFind()
        {
            // Arrange
            var mockedSet = new Mock<DbSet<FakeRepositoryType>>();

            var mockedDbContext = new Mock<ICookingTimeDbContext>();
            mockedDbContext.Setup(x => x.DbSet<FakeRepositoryType>()).Returns(mockedSet.Object);

            var repository = new EntityFrameworkRepository<FakeRepositoryType>(mockedDbContext.Object);

            // Act
            repository.GetById(1);

            // Assert
            mockedSet.Verify(x => x.Find(1), Times.Once);
        }

        [Test]
        public void ReturnCorrectValue()
        {
            // Arrange
            var mockedResult = new Mock<FakeRepositoryType>();

            var mockedSet = new Mock<DbSet<FakeRepositoryType>>();
            mockedSet.Setup(s => s.Find(It.IsAny<object>())).Returns(mockedResult.Object);

            var mockedDbContext = new Mock<ICookingTimeDbContext>();
            mockedDbContext.Setup(x => x.DbSet<FakeRepositoryType>()).Returns(mockedSet.Object);

            var repository = new EntityFrameworkRepository<FakeRepositoryType>(mockedDbContext.Object);

            // Act
            var result = repository.GetById(1);

            // Assert
            Assert.AreSame(mockedResult.Object, result);
        }
    }
}
