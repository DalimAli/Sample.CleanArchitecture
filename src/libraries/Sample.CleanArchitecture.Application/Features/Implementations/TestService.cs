using Sample.CleanArchitecture.Application.Features.Interfaces;
using Sample.CleanArchitecture.Application.Infrastructure;
using Sample.CleanArchitecture.Domain.Entities;

namespace Sample.CleanArchitecture.Application.Features.Implementations;

public class TestService(ITestRepository testRepository) : ITestService
{
   
    #region NOT_OVERRIDEABLE

    public Task<Test> FindAsync(long Id)
    {
        return testRepository.FirstOrDefaultAsync(Id);
    }

    #endregion


    #region OVERRIDEABLE

    // CREATE
    public virtual async Task<Test> InsertAsync(Test entity)
    {
        await testRepository.InsertAsync(entity);
        return entity;
    }

    public virtual async Task<List<Test>> InsertRangeAsync(List<Test> entities)
    {
        await testRepository.InsertRangeAsync(entities);
        return entities;
    }

    // READ
    public virtual async Task<Test> FirstOrDefaultAsync(long id)
    {
        return await testRepository.FirstOrDefaultAsync(id);
    }

    public virtual async Task<List<Test>> GetAllAsync()
    {
        var list = await testRepository.GetAllAsync();
        return list;
    }

    public async virtual Task<IReadOnlyList<Test>> GetPagedAsync(int page, int size)
    {
        return await testRepository.GetPagedAsync(page, size);
    }

    /// UPDATE
    public virtual async Task<Test> UpdateAsync(Test entity)
    {
        await testRepository.UpdateAsync(entity);
        return entity;
    }

    public virtual async Task<Test> UpdateAsync(long id, Test entity)
    {
        await testRepository.UpdateAsync(entity);
        return entity;
    }

    public virtual async Task<List<Test>> UpdateRangeAsync(List<Test> entities)
    {
        await testRepository.UpdateRangeAsync(entities);
        return entities;
    }


    /// DELETE
    public virtual async Task DeleteAsync(Test entity)
    {
        await testRepository.DeleteAsync(entity);

    }

    public virtual async Task DeleteAsync(long id)
    {
        await testRepository.DeleteAsync(id);
    }

    public virtual async Task DeleteRangeAsync(List<Test> entities)
    {
        await testRepository.DeleteRangeAsync(entities);
    }

    #endregion
    public List<Test> GetTestWithTreatments(long id)
    {
        return testRepository.GetTestWithTreatments(id);
    }
}
