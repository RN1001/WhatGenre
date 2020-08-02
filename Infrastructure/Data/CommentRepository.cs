using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CommentRepository : EfRepository<Comment>, ICommentRepository
    {

        private readonly WhatGenreContext whatGenreContext;

        public CommentRepository(WhatGenreContext whatGenreContext) : base(whatGenreContext)
        {
            this.whatGenreContext = whatGenreContext;
        }

        public async Task<List<Comment>> FindAllCommentsByPostIdAsync(int? id)
        {
            var comments = await whatGenreContext.Comments.Where(p => p.PostId == id).ToListAsync();
            return comments;
        }
    }
}
