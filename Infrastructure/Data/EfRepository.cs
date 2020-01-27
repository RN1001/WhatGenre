using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data
{
    public class EfRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly WhatGenreContext _context;

        public EfRepository(WhatGenreContext context)
        {
            _context = context;
        }

        public List<T> FindAll()
        {
            return _context.Set<T>().ToList();
        }

        public T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
