using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatGenre.Interfaces
{
    public interface IGenericRepository<T>
    {
        public T FindById(int id);

        public List<T> FindAll();
    }
}
