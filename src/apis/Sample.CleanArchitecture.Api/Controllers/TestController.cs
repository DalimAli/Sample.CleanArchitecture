using Microsoft.AspNetCore.Mvc;
using Sample.CleanArchitecture.Application.Features.Interfaces;
using Sample.CleanArchitecture.Domain.Entities;

namespace Sample.CleanArchitecture.Api.Controllers;

[Route("api/test")]
[ApiController]
public class TestController(ITestService testService) : ControllerBase
{

    [HttpGet("get/{id}")]
    public async Task<Test> Get(long id)
    {
       return await testService.FindAsync(id);
    }

    [HttpGet("gets")]
    public async Task<List<Test>> Gets()
    {
        return await testService.GetAllAsync();
    }

    [HttpGet("gets/{page}/{size}")]
    public async Task<IReadOnlyList<Test>> Gets(int page, int size)
    {
        return await testService.GetPagedAsync(page, size);
    }

    [HttpPost("add")]
    public async Task<Test> Post([FromBody] Test test)
    {
       return await testService.InsertAsync(test);
    }

    [HttpPatch("update")]
    public async Task<Test> Update([FromBody] Test test) 
    {
        return await testService.UpdateAsync(test);
    }

    [HttpDelete("delete/{id}")]
    public async Task Delete(int id)
    {
        await testService.DeleteAsync(id);
    }
}
