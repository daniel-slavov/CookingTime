using CookingTime.Data;
using CookingTime.Data.Contracts;
using CookingTime.Tests.Data.Repository.Fakes;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace CookingTime.Tests.Data.Repository
{
    [TestFixture]
    public class AllShould
    {
        private IQueryable<FakeRepositoryType> GetData()
        {
            return new List<FakeRepositoryType>
            {
               new FakeRepositoryType(),
               new FakeRepositoryType(),
               new FakeRepositoryType()
            }.AsQueryable();
        }

        [Test]
        public void CallDbContextSet()
        {
            // Arrange
            var data = this.GetData();

            var mockedSet = new Mock<IDbSet<FakeRepositoryType>>();
            mockedSet.Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockedDbContext = new Mock<ICookingTimeDbContext>();
            mockedDbContext.Setup(x => x.DbSet<FakeRepositoryType>()).Returns(mockedSet.Object);

            var repository = new EntityFrameworkRepository<FakeRepositoryType>(mockedDbContext.Object);

            // Act
            var result = repository.All;

            // Assert
            mockedDbContext.Verify(db => db.DbSet<FakeRepositoryType>(), Times.Once);
        }
    }
}
