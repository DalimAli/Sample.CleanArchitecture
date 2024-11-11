using Microsoft.Extensions.DependencyInjection;
using Sample.CleanArchitecture.Application.Features.Implementations;
using Sample.CleanArchitecture.Application.Features.Interfaces;

namespace Sample.CleanArchitecture.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITestService, TestService>();
        return services;
    }
}
