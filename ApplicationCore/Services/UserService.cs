using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User GetUserById(int id)
        {
            return userRepository.FindById(id);
        }

        public List<User> GetAllUsers()
        {
            return userRepository.FindAll();
        }
    }
}
