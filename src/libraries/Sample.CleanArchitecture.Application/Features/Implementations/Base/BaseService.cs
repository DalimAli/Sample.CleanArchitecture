using Sample.CleanArchitecture.Application.Features.Interfaces.Base;
using Sample.CleanArchitecture.Application.Infrastructure;

namespace Sample.CleanArchitecture.Application.Features.Implementations.Base;

public class BaseService<T> : IBaseService<T> where T : class
{
    private readonly IBaseRepository<T> _repository;
    public BaseService(IBaseRepository<T> repository)
    {
        _repository = repository;
    }

    #region NOT_OVERRIDEABLE

    public Task<T> FindAsync(long Id)
    {
        return _repository.FirstOrDefaultAsync(Id);
    }

    #endregion


    #region OVERRIDEABLE

    // CREATE
    public virtual async Task<T> InsertAsync(T entity)
    {
        await _repository.InsertAsync(entity);
        return entity;
    }

    public virtual async Task<List<T>> InsertRangeAsync(List<T> entities)
    {
        await _repository.InsertRangeAsync(entities);
        return entities;
    }

    // READ
    public virtual async Task<T> FirstOrDefaultAsync(long id)
    {
        return await _repository.FirstOrDefaultAsync(id);
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        var list = await _repository.GetAllAsync();
        return list;
    }


    /// UPDATE
    public virtual async Task<T> UpdateAsync(T entity)
    {
        await _repository.UpdateAsync(entity);
        return entity;
    }

    public virtual async Task<T> UpdateAsync(long id, T entity)
    {
        await _repository.UpdateAsync(entity);
        return entity;
    }

    public virtual async Task<List<T>> UpdateRangeAsync(List<T> entities)
    {
        await _repository.UpdateRangeAsync(entities);
        return entities;
    }


    /// DELETE
    public virtual async Task DeleteAsync(T entity)
    {
        await _repository.DeleteAsync(entity);

    }

    public virtual async Task DeleteAsync(long id)
    {
        await _repository.DeleteAsync(id);
    }

    public virtual async Task DeleteRangeAsync(List<T> entities)
    {
        await _repository.DeleteRangeAsync(entities);
    }

    #endregion
}
