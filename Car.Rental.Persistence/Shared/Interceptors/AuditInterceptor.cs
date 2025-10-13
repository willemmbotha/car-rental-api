using Car.Rental.Domain.Shared;
using Car.Rental.Persistence.Common.UserContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Car.Rental.Persistence.Common.Interceptors;

public class AuditInterceptor(CurrentUserContext currentUserContext) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null) 
            return base.SavingChangesAsync(eventData, result, cancellationToken);

        var entries = eventData.Context.ChangeTracker.Entries<AuditableEntity>();

        foreach (var entry in entries)
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTimeOffset.UtcNow;
                    entry.Entity.CreatedBy = currentUserContext.Username ?? 
                                             throw new InvalidOperationException("Current user is null");
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedDate = DateTimeOffset.UtcNow;
                    entry.Entity.ModifiedBy  = currentUserContext.Username ?? 
                                               throw new InvalidOperationException("Current user is null");
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.DeletedDate = DateTimeOffset.UtcNow;
                    entry.Entity.DeletedBy  = currentUserContext.Username ?? 
                                              throw new InvalidOperationException("Current user is null");
                    entry.Entity.IsDeleted = true;
                    break;
            }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}