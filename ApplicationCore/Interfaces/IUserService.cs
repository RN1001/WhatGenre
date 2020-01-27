using ApplicationCore.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IUserService
    {
        public User GetUserById(int id);

        public List<User> GetAllUsers();

    }
}
