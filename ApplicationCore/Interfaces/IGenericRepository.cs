using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<T> FindByIdAsync(int id);

        public Task<List<T>> FindAllAsync();
    }
}
