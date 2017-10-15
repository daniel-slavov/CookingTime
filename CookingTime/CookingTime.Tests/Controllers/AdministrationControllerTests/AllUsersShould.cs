using CookingTime.Authentication.Contracts;
using CookingTime.Models;
using CookingTime.Services.Contracts;
using CookingTime.Web.Areas.Administration.Controllers;
using CookingTime.Web.Areas.Administration.Models;
using CookingTime.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace CookingTime.Tests.Controllers.AdministrationControllerTests
{
    [TestFixture]
    public class AllUsersShould
    {
        [TestCase(null)]
        [TestCase(1)]
        public void CallUserServiceGetAll(int? page)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new AdministrationController(mockedProvider.Object, mockedRecipeService.Object, mockedUserService.Object, mockedFactory.Object);

            // Act
            controller.AllUsers(page);

            // Assert
            mockedUserService.Verify(s => s.GetAll(), Times.Once);
        }

        [TestCase(null, true)]
        [TestCase(1, true)]
        [TestCase(null, false)]
        [TestCase(1, false)]
        public void ReturnCorrectViewWithModel(int? page, bool isAdmin)
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var user = new User();
            var viewModel = new UserAdministrationViewModel(userId, "username", isAdmin);
            var users = new List<User> { user }.AsEnumerable();
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(x => x.GetAll()).Returns(users);
            var mockedRecipeService = new Mock<IRecipeService>();
            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(x => x.CreateUserAdminViewModel(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>())).Returns(viewModel);

            var controller = new AdministrationController(mockedProvider.Object, mockedRecipeService.Object, mockedUserService.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.AllUsers(page))
                .ShouldRenderDefaultView()
                .WithModel<PagedList<UserAdministrationViewModel>>(m =>
                {
                    Assert.AreEqual(m.PageSize, 10);
                    Assert.AreEqual(m.PageNumber, 1);
                    Assert.AreEqual(m.Count, 1);
                    Assert.AreSame(m[0], viewModel);
                }
                );
        }
    }
}
