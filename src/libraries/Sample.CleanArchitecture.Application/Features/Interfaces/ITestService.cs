using Sample.CleanArchitecture.Domain.Entities;

namespace Sample.CleanArchitecture.Application.Features.Interfaces;

public interface ITestService
{
    #region NOT_OVERRIDEABLE
    Task<Test> FindAsync(long Id);

    #endregion

    #region OVERRIDEABLE

    Task<Test> InsertAsync(Test entity);

    Task<List<Test>> InsertRangeAsync(List<Test> entities);


    Task<Test> FirstOrDefaultAsync(long id);

    Task<List<Test>> GetAllAsync();

    Task<IReadOnlyList<Test>> GetPagedAsync(int page, int size);


    Task<Test> UpdateAsync(Test entity);

    Task<Test> UpdateAsync(long id, Test entity);

    Task<List<Test>> UpdateRangeAsync(List<Test> entities);


    Task DeleteRangeAsync(List<Test> entities);

    Task DeleteAsync(Test entity);

    Task DeleteAsync(long id);

    #endregion
}
