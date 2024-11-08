using Microsoft.EntityFrameworkCore;
using Sample.CleanArchitecture.Application.Infrastructure;
using Sample.CleanArchitecture.Domain.Entities;
using Sample.CleanArchitecture.Infrastructure.Context;
using static System.Net.Mime.MediaTypeNames;

namespace Sample.CleanArchitecture.Infrastructure.Repository.Feature;

public class TestRepository(ApplicationDbContext dbContext) : BaseRepository<Test>(dbContext), ITestRepository
{
    public List<Test> GetTestWithTreatments(long id)
    {
        var tests = dbContext.Tests
               .Include(x => x.Treatments)
               .Where(x => x.Id == id)
               .ToList();

        return tests;
    }

    public override async Task UpdateAsync(Test entity)
    {
        await dbContext.Tests.Where(x => x.Id == entity.Id)
               .ExecuteUpdateAsync(tests =>
               tests.SetProperty(o => o.Name, entity.Name)
                    .SetProperty(o => o.Cost, entity.Cost)
                    .SetProperty(o => o.UpdatedDateUtc, DateTime.UtcNow));
        await dbContext.SaveChangesAsync();
    }
}
