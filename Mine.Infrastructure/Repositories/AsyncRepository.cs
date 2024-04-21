using Microsoft.EntityFrameworkCore;
using Mine.Application.Contracts.Persistence;
using Mine.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mine.Infrastructure.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public AsyncRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public IQueryable<T> QueryInContext(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<T> GetFirstAsync()
        {
            return await _dbSet.FirstOrDefaultAsync();
        }

        public async Task<T> GetFirstAsync(Expression<Func<T, object>> orderby)
        {
            return await _dbSet.OrderBy(orderby).FirstOrDefaultAsync();
        }

        public async Task<T> GetFirstWhereAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderby)
        {
            return await _dbSet.Where(predicate).OrderBy(orderby).FirstOrDefaultAsync();
        }

        public async Task<T> GetLastAsync(Expression<Func<T, object>> orderby)
        {
            return await _dbSet.OrderByDescending(orderby).FirstOrDefaultAsync();
        }

        public async Task<T> GetLastWhereAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderby)
        {
            return await _dbSet.Where(predicate).OrderByDescending(orderby).FirstOrDefaultAsync();
        }

        public async Task<T> GetSingleWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Paged<T>> PagedDscAllAsync(Expression<Func<T, object>> orderby, int page, int size = 10)
        {
            var totalCount = await _dbSet.CountAsync();
            var items = await _dbSet.OrderByDescending(orderby).Skip((page - 1) * size).Take(size).ToListAsync();
            return new Paged<T>(items, page, size, totalCount);
        }

        public async Task<List<T>> ListAllWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateRangeAsync(ICollection<T> entities)
        {
            _dbSet.UpdateRange(entities);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteRangeAsync(ICollection<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        {
            return await _dbSet.Skip((page - 1) * size).Take(size).ToListAsync();
        }

        public IQueryable<T> Include(Expression<Func<T, object>> predicate)
        {
            return _dbSet.Include(predicate);
        }

        async Task<Paged<T>> IAsyncRepository<T>.PagedAscAllAsync(Expression<Func<T, object>> orderby, int page, int size)
        {
            var totalCount = await _dbSet.CountAsync();
            var items = await _dbSet.OrderBy(orderby).Skip((page - 1) * size).Take(size).ToListAsync();
            return new Paged<T>(items, page, size, totalCount);
        }

        async Task<Paged<T>> IAsyncRepository<T>.PagedDscAllAsync(Expression<Func<T, object>> orderby, int page, int size)
        {
            var totalCount = await _dbSet.CountAsync();
            var items = await _dbSet.OrderByDescending(orderby).Skip((page - 1) * size).Take(size).ToListAsync();
            return new Paged<T>(items, page, size, totalCount);
        }

        async Task<Paged<T>> IAsyncRepository<T>.PagedAscWhereAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderby, int page, int size)
        {
            var totalCount = await _dbSet.CountAsync(predicate);
            var items = await _dbSet.Where(predicate).OrderBy(orderby).Skip((page - 1) * size).Take(size).ToListAsync();
            return new Paged<T>(items, page, size, totalCount);
        }

        async Task<Paged<T>> IAsyncRepository<T>.PagedDscWhereAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderby, int page, int size)
        {
            var totalCount = await _dbSet.CountAsync(predicate);
            var items = await _dbSet.Where(predicate).OrderByDescending(orderby).Skip((page - 1) * size).Take(size).ToListAsync();
            return new Paged<T>(items, page, size, totalCount);
        }
    }
}
