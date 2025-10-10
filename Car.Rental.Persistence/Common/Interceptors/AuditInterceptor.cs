using Car.Rental.Persistence.Common.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Car.Rental.Persistence.Common.Interceptors;

public class AuditInterceptor: SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null) return base.SavingChangesAsync(eventData, result, cancellationToken);

        var entries = eventData.Context.ChangeTracker.Entries<AuditableEntity>();

        foreach (var entry in entries)
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTimeOffset.UtcNow;
                    entry.Entity.CreatedBy = string.Empty;
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedDate = DateTimeOffset.UtcNow;
                    entry.Entity.ModifiedBy = string.Empty;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.DeletedDate = DateTimeOffset.UtcNow;
                    entry.Entity.DeletedBy = string.Empty;
                    entry.Entity.IsDeleted = true;
                    break;
            }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}