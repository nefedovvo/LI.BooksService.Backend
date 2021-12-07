using LI.BookService.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LI.BookService.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BookServiceDbContext _context;

        public GenericRepository(BookServiceDbContext context)
        {
            _context = context;
        }
        public IQueryable<T> Query(bool ignoreGlobalFilters = false)
        {
            return ignoreGlobalFilters
                ? this._context.Set<T>().IgnoreQueryFilters()
                : this._context.Set<T>();
        }

        public async Task CreateAsync(T item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var dbSet = _context.Set<T>();
            var item = await dbSet.FindAsync(id);

            if (item == null)
                return false;

            _context.Entry(item).State = EntityState.Detached;
            return true;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(T item)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

    }
}
