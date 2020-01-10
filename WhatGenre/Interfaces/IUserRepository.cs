using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatGenre.Models;

namespace WhatGenre.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int id);
        List<User> GetUsers();
        
    }
}
