using CookingTime.Data.Contracts;
using CookingTime.Models;
using CookingTime.Services;
using Moq;
using NUnit.Framework;

namespace CookingTime.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class GetByIdShould
    {
        [Test]
        public void CallRepositoryGetById()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.GetById("4a1dc234-6cf6-41b6-a65a-45df40a2baf6");

            // Assert
            mockedRepository.Verify(r => r.GetById("4a1dc234-6cf6-41b6-a65a-45df40a2baf6"), Times.Once);
        }

        [Test]
        public void ReturnCorrectData()
        {
            // Arrange
            var mockedUser = new Mock<User>();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(mockedUser.Object);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            var result = service.GetById("4a1dc234-6cf6-41b6-a65a-45df40a2baf6");

            // Assert
            Assert.AreSame(mockedUser.Object, result);
        }
    }
}
