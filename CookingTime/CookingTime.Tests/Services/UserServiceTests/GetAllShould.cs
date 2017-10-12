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
    public class GetAllShould
    {
        [Test]
        public void CallRepositoryGetAll()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.GetAll();

            // Assert
            mockedRepository.Verify(r => r.All, Times.Once);
        }

        [Test]
        public void ReturnCorrectResult()
        {
            // Arrange
            var users = new List<User> { new User() }
                .AsQueryable();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.All).Returns(users);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            var result = service.GetAll();

            // Assert
            CollectionAssert.AreEqual(users, result);
        }
    }
}
