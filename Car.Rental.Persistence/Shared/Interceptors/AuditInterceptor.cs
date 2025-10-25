using Car.Rental.Domain.Shared;
using Car.Rental.Domain.Shared.UserContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Car.Rental.Persistence.Shared.Interceptors;

public class AuditInterceptor(CurrentUserContext currentUserContext) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken ct = default)
    {
        if (eventData.Context is null)
            return base.SavingChangesAsync(eventData, result, ct);

        var entries = eventData.Context.ChangeTracker.Entries<AuditableEntity>();

        foreach (var entry in entries)
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTimeOffset.UtcNow;
                    entry.Entity.CreatedBy = currentUserContext.DescopeUserId ??
                                             throw new InvalidOperationException("Current user is null");
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedDate = DateTimeOffset.UtcNow;
                    entry.Entity.ModifiedBy = currentUserContext.DescopeUserId ??
                                              throw new InvalidOperationException("Current user is null");
                    break;
                case EntityState.Deleted:
                    if (entry.Entity.IgnoreSoftDelete is true)
                        continue;

                    entry.State = EntityState.Modified;
                    entry.Entity.DeletedDate = DateTimeOffset.UtcNow;
                    entry.Entity.DeletedBy = currentUserContext.DescopeUserId ??
                                             throw new InvalidOperationException("Current user is null");
                    entry.Entity.IsDeleted = true;
                    break;
            }

        return base.SavingChangesAsync(eventData, result, ct);
    }
}