﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DMBD.Kernel.Service
{
    public interface IService<T> where T : class 
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> Any(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);

        void Delete(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
