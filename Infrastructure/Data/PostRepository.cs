using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PostRepository : EfRepository<Post>, IPostRepository
    {
        private readonly WhatGenreContext context;

        public PostRepository(WhatGenreContext whatGenreContext) : base(whatGenreContext)
        {
            context = whatGenreContext;
        }

    }
}
