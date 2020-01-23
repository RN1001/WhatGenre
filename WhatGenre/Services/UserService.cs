using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatGenre.Interfaces;
using WhatGenre.Models;

namespace WhatGenre.Services
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
