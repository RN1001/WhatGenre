using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    /// <summary>
    /// hint for self, UserRepo inherits generics methods form EFRepo, and custom domain specific methods from the IUserRepo
    /// </summary>
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        private readonly WhatGenreContext context;

        public UserRepository(WhatGenreContext whatGenreContext) : base(whatGenreContext)
        {
            context = whatGenreContext;
        }

    }
}
