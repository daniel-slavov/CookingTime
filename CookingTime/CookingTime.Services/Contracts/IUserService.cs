using System.Collections.Generic;
using CookingTime.Models;

namespace CookingTime.Services.Contracts
{
    public interface IUserService
    {
        User GetUserById(string id);

        User GetUserByUsername(string username);

        IEnumerable<User> GetUsers();
    }
}