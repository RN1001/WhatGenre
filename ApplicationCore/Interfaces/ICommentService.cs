using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICommentService
    {
        public Task<Comment> GetCommentById(int? id);

        public Task<List<Comment>> GetAllComments();

        public Task<Comment> Save(Comment comment);

        public Task<Comment> Edit(int? id);

        public Task<Comment> Delete(int? id);

        public Task<List<Comment>> FindAllCommentsByPostIdAsync(int? id);

    }
}
