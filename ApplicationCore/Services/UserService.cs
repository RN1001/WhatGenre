using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> GetUserById(int id)
        {
            return await userRepository.FindByIdAsync(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await userRepository.FindAllAsync();
        }
    }
}
