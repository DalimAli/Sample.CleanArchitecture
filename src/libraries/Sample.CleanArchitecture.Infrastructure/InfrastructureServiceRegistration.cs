using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.CleanArchitecture.Application.Infrastructure;
using Sample.CleanArchitecture.Infrastructure.Context;
using Sample.CleanArchitecture.Infrastructure.Data.Interceptor;
using Sample.CleanArchitecture.Infrastructure.Repository;
using Sample.CleanArchitecture.Infrastructure.Repository.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.CleanArchitecture.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<ISaveChangesInterceptor, AuditableEntityInterceptor>();

            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                options.AddInterceptors(serviceProvider.GetService<ISaveChangesInterceptor>());
                options.UseSqlServer(configuration.GetConnectionString("CleanArchConnectionString"));
                options.LogTo(x => Console.WriteLine(x));
            }, ServiceLifetime.Singleton);

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITestRepository, TestRepository>();

            return services;
        }
    }
}
