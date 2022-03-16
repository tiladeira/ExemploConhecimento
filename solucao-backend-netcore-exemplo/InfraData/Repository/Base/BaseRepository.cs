using Domain.Entities.Base;
using Domain.Interfaces.Repository.Base;

using InfraData.Context;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfraData.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        #region Fields

        protected readonly DBContextEFCore _context;
        protected readonly DbSet<T> _dataset;

        #endregion

        #region Ctor

        public BaseRepository(DBContextEFCore context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }

        #endregion

        #region Methods

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(id));

            if (item is null)
                return false;

            _dataset.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TruncateAsync()
        {
            _dataset.RemoveRange(_dataset);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var items = await _dataset.ToListAsync();
            return items;
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dataset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var item = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(id));
            return item;
        }

        public async Task<T> InsertAsync(T item)
        {
            await _dataset.AddAsync(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<IEnumerable<T>> InsertAsync(IEnumerable<T> items)
        {
            await _dataset.AddRangeAsync(items);
            await _context.SaveChangesAsync();

            return items;
        }

        public async Task<T> UpdateAsync(T item)
        {
            var result = await _dataset.FindAsync(item.Id);

            if (result is null)
                return null;

            _dataset.Update(item);
            await _context.SaveChangesAsync();

            return item;
        }

        #endregion
    }
}
