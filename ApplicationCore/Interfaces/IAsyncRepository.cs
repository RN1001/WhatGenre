using ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        public Task<T> FindByIdAsync(int? id);

        public Task<List<T>> FindAllAsync();

        public Task<T> SaveAsync(T t);

        public Task<T> EditAsync(int? id, T t);

        public Task<T> DeleteAsync(int? id);

    }
}
