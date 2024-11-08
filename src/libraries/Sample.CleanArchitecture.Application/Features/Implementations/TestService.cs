using Microsoft.EntityFrameworkCore;
using Sample.CleanArchitecture.Application.Features.Implementations.Base;
using Sample.CleanArchitecture.Application.Features.Interfaces;
using Sample.CleanArchitecture.Application.Infrastructure;
using Sample.CleanArchitecture.Domain.Entities;

namespace Sample.CleanArchitecture.Application.Features.Implementations;

//public class TestService(IBaseRepository<Test> testRepository) : BaseService<Test>(testRepository), ITestService
//{
//    //private readonly IBaseRepository<Test> _repository;

//    public List<Test> GetTestWithTreatments(long id)
//    {
//        return tests;
//    }
//}

public class TestService(ITestRepository testRepository) : BaseService<Test>(testRepository), ITestService
{
    public List<Test> GetTestWithTreatments(long id)
    {
        return testRepository.GetTestWithTreatments(id);
    }
}
