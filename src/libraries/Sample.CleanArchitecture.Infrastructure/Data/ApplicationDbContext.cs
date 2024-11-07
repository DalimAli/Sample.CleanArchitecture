using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Sample.CleanArchitecture.Domain.Entities;

namespace Sample.CleanArchitecture.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    protected ApplicationDbContext(DbContextOptions contextOptions) : base(options: contextOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
           .SelectMany(t => t.GetProperties())
           .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18,2)");
        }

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Test> Tests { get; set; }
}
