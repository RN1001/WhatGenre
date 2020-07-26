using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
