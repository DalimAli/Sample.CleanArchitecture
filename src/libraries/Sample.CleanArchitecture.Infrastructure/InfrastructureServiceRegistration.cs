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

            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CleanArchConnectionString")));

            // services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ITestRepository, TestRepository>();
            

            return services;
        }
    }
}
