using ApplicationCore.Entities;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
  
        public Task<string> GetFullName();
    }
}
