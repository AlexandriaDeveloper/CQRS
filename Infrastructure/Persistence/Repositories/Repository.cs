using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contract;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly EmployeeContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(EmployeeContext context)
        {
            this._context = context;
            this._dbSet = this._context.Set<T>();

        }
        public async Task<T> AddAsync(T entity)
        {
            await this._dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            this._dbSet.Remove(entity);
            return entity;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            this._dbSet.Update(entity);
            return entity;
        }
    }
}