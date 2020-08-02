using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IPostService 
    {
        public Task<Post> GetPostById(int? id);

        public Task<List<Post>> GetAllPosts();

        public Task<Post> Save(Post post);

        public Task<Post> Edit(int? id);

        public Task<Post> Delete(int? id);

    }
}
