using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.CleanArchitecture.Application.Features.Interfaces.Base;

public interface IBaseService<T> where T : class
{
    #region NOT_OVERRIDEABLE
    Task<T> FindAsync(long Id);

    #endregion

    #region OVERRIDEABLE

    Task<T> InsertAsync(T entity);

    Task<List<T>> InsertRangeAsync(List<T> entities);


    Task<T> FirstOrDefaultAsync(long id);

    Task<List<T>> GetAllAsync();


    Task<T> UpdateAsync(T entity);

    Task<T> UpdateAsync(long id, T entity);

    Task<List<T>> UpdateRangeAsync(List<T> entities);


    Task DeleteRangeAsync(List<T> entities);

    Task DeleteAsync(T entity);

    Task DeleteAsync(long id);

    #endregion
}
