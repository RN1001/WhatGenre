using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatGenre.Models;

namespace WhatGenre.Interfaces
{
    public interface IUserService
    {

        public User GetUserById(int id);

        public List<User> GetAllUsers();

    }
}
