using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class CommentService : ICommentService
    {

        private readonly ICommentRepository commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await commentRepository.FindAllAsync();
        }

        public async Task<Comment> GetCommentById(int? id)
        {
            return await commentRepository.FindByIdAsync(id);
        }

        public async Task<Comment> Save(Comment comment)
        {
            return await commentRepository.SaveAsync(comment);
        }
        public async Task<Comment> Edit(int? id, Comment comment)
        {
            return await commentRepository.EditAsync(id, comment);
        }

        public async Task<Comment> Delete(int? id)
        {
            return await commentRepository.DeleteAsync(id);
        }

        public async Task<List<Comment>> FindAllCommentsByPostIdAsync(int? id)
        {
            return await commentRepository.FindAllCommentsByPostIdAsync(id);
        }
    }
}
