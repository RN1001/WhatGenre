using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {

        public UserRepository(WhatGenreContext whatGenreContext) : base(whatGenreContext)
        {

        }

        public Task<string> GetFullName()
        {
            throw new System.NotImplementedException();
        }



    }
}
