using System.Collections.Generic;
using CookingTime.Models;

namespace CookingTime.Services.Contracts
{
    public interface IUserService
    {
        User GetById(string id);

        User GetByUsername(string username);

        IEnumerable<User> GetAll();
    }
}