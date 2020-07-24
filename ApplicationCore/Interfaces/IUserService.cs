using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserById(int? id);

        public Task<List<User>> GetAllUsers();

        public Task<User> Save(User user);

        public Task<User> Edit(int? id);

        public Task<User> Delete(int? id);
    }
}
