using Sample.CleanArchitecture.Application.Infrastructure;
using Sample.CleanArchitecture.Domain.Entities;
using Sample.CleanArchitecture.Infrastructure.Context;

namespace Sample.CleanArchitecture.Infrastructure.Repository.Feature;

public class TestRepository(ApplicationDbContext dbContext): BaseRepository<Test>(dbContext), ITestRepository
{

}
