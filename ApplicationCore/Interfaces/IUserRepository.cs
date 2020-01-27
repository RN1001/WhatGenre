using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public string GetFullName();
    }
}
