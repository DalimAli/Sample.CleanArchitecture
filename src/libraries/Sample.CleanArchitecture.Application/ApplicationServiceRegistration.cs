using Microsoft.Extensions.DependencyInjection;
using Sample.CleanArchitecture.Application.Features.Implementations;
using Sample.CleanArchitecture.Application.Features.Implementations.Base;
using Sample.CleanArchitecture.Application.Features.Interfaces;
using Sample.CleanArchitecture.Application.Features.Interfaces.Base;

namespace Sample.CleanArchitecture.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

        services.AddScoped<ITestService, TestService>();
        return services;
    }
}
