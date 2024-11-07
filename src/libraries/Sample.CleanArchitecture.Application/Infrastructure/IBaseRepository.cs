using System.Linq.Expressions;

namespace Sample.CleanArchitecture.Application.Infrastructure;

public interface IBaseRepository<T> where T : class
{
    IQueryable<T> Query();
    Task<T> FirstOrDefaultAsync(object id);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    Task InsertAsync(T entity);
    Task InsertRangeAsync(List<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(List<T> entities);
    Task DeleteAsync(object id);
    Task DeleteRangeAsync(List<T> entities);
    Task DeleteAsync(T entity);
}
