using CookingTime.Data.Contracts;
using CookingTime.Models;
using CookingTime.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CookingTime.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class GetByUsernameShould
    {
        [Test]
        public void CallRepositoryAll()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.GetByUsername("username");

            // Assert
            mockedRepository.Verify(r => r.All, Times.Once());
        }

        [Test]
        public void ReturnCorrectData()
        {
            // Arrange
            var user = new User { UserName = "username" };

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.All)
                .Returns(new List<User> { user }.AsQueryable());

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            var result = service.GetByUsername("username");

            // Assert
            Assert.AreSame(user, result);
        }
    }
}
