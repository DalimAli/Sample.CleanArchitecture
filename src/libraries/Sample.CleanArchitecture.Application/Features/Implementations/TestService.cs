using Sample.CleanArchitecture.Application.Features.Implementations.Base;
using Sample.CleanArchitecture.Application.Infrastructure;
using Sample.CleanArchitecture.Domain.Entities;

namespace Sample.CleanArchitecture.Application.Features.Implementations;

public class TestService(ITestRepository testRepository): BaseService<Test>(testRepository)
{

}
