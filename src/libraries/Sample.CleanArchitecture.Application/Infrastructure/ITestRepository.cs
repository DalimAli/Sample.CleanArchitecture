using Sample.CleanArchitecture.Domain.Entities;

namespace Sample.CleanArchitecture.Application.Infrastructure;

public interface ITestRepository : IBaseRepository<Test>
{
    List<Test> GetTestWithTreatments(long id);
}
