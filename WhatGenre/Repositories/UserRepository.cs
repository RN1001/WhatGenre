using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<User> FindAll()
        {
            return _context.Set<User>().ToList();
        }

        public User FindById(int id)
        {
            return _context.Users.Find(id);
        }

    }
}
