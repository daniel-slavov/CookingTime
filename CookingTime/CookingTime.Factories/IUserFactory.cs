using CookingTime.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTime.Factories
{
    public interface IUserFactory
    {
        User CreateUser(string username, string hashedPassword, ICollection<Recipe> recipes);
    }
}
