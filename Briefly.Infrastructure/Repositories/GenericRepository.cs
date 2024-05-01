using Briefly.Infrastructure.Context;
using Briefly.Infrastructure.IRepositoties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbset;   

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }
        public virtual async Task AddAsync(T entity)
        {
            var result = await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            var res = _dbset.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }
        // get 
        public IQueryable<T> GetTableNoTracking()
        {
           return _dbset.AsNoTracking().AsQueryable();
        }

        public async Task UpdateAsync(T entity)
        {
             _dbset.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
