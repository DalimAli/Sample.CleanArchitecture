using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Sample.CleanArchitecture.Domain.Common;

namespace Sample.CleanArchitecture.Infrastructure.Data.Interceptor;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {

        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void UpdateEntities(DbContext? context)
    {
        if (context == null) return;
        var now = DateTime.UtcNow;

        foreach (var entry in context.ChangeTracker.Entries<Audit>())
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.Entity.UpdatedBy = null;
                    entry.Entity.UpdatedDateUtc = now;
                    break;
                case EntityState.Added:
                    entry.Entity.CreatedDateUtc = now;
                    entry.Entity.CreatedBy = null;
                    break;

            }
        }
    }
}

