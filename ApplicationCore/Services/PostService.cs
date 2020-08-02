using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;

        public PostService(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public async Task<Post> GetPostById(int? id)
        {
            return await postRepository.FindByIdAsync(id);
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await postRepository.FindAllAsync();
        }

        public async Task<Post> Save(Post post)
        {
            return await postRepository.SaveAsync(post);
        }

        public async Task<Post> Edit(int? id)
        {
            return await postRepository.EditAsync(id);
        }

        public async Task<Post> Delete(int? id)
        {
            return await postRepository.DeleteAsync(id);
        }


    }
}
