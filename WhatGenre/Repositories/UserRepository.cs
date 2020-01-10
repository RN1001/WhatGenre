using System;
using System.Collections.Generic;
using WhatGenre.Interfaces;
using WhatGenre.Models;

namespace WhatGenre.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly WhatGenreContext _context;

        public UserRepository(WhatGenreContext context)
        {
            _context = context;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
