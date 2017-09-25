using CookingTime.Models;

namespace CookingTime.Factories
{
    public interface IUserFactory
    {
        User CreateUser(string username, string email);
    }
}
