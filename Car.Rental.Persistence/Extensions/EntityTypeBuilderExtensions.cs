using System.Reflection;
using Car.Rental.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car.Rental.Persistence.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static EntityTypeBuilder ConfigureAuditFields<TEntity>(this EntityTypeBuilder<TEntity> entityTypeBuilder)
        where TEntity : AuditableEntity
    {
        IEnumerable<PropertyInfo> allEntityProps =
            typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in allEntityProps)
        {
            switch (prop.Name)
            {
                case nameof(AuditableEntity.Id):
                    entityTypeBuilder.HasKey(prop.Name);
                    break;
                case nameof(AuditableEntity.IsDeleted):
                    entityTypeBuilder.HasIndex(prop.Name).HasFilter($"\"{prop.Name}\" = false");
                    entityTypeBuilder.HasQueryFilter(e => !e.IsDeleted);
                    break;
                case nameof(AuditableEntity.RowVersion):
                    entityTypeBuilder.Property(prop.Name).IsRowVersion();
                    break;
            }
        }
        return entityTypeBuilder;
    }
}