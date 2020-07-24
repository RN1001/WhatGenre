using ApplicationCore.Entities;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUserRepository : IAsyncRepository<User>
    {

    }
}
