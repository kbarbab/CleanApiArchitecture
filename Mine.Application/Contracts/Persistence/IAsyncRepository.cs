using Mine.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mine.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        IQueryable<T> QueryInContext(Expression<Func<T, bool>> predicate);

        Task<T> GetFirstAsync();
        Task<T> GetFirstAsync(Expression<Func<T, object>> orderby);
        Task<T> GetFirstWhereAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderby);
        Task<T> GetLastAsync(Expression<Func<T, object>> orderby);
        Task<T> GetLastWhereAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderby);

        Task<T> GetSingleWhereAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> ListAllAsync();

        Task<Paged<T>> PagedAscAllAsync(Expression<Func<T, object>> orderby, int page, int size=10);
        Task<Paged<T>> PagedDscAllAsync(Expression<Func<T, object>> orderby, int page, int size=10);

        Task<List<T>> ListAllWhereAsync(Expression<Func<T, bool>> predicate);
        Task<Paged<T>> PagedAscWhereAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderby, int page, int size = 10);
        Task<Paged<T>> PagedDscWhereAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderby, int page, int size = 10);

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<int> UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
        Task<int> DeleteRangeAsync(ICollection<T> entities);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
        IQueryable<T> Include(Expression<Func<T, object>> predicate);
    }
}
