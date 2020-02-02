using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EfRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly WhatGenreContext _context;

        public EfRepository(WhatGenreContext context)
        {
            _context = context;
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
