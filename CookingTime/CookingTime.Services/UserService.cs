using System;
using System.Collections.Generic;
using System.Linq;
using CookingTime.Data.Contracts;
using CookingTime.Models;
using CookingTime.Services.Contracts;

namespace CookingTime.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<User> userRepository,
            IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public User GetUserById(string id)
        {
            return this.userRepository.GetById(id);
        }

        public User GetUserByUsername(string username)
        {
            var user = this.userRepository
                .All
                .FirstOrDefault(u => u.UserName.Equals(username));

            return user;
        }        

        public IEnumerable<User> GetUsers()
        {
            return this.userRepository.All
                .ToList();
        }
    }
}
