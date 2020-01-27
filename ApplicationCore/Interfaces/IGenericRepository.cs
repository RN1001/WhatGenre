using ApplicationCore.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public T FindById(int id);

        public List<T> FindAll();
    }
}
