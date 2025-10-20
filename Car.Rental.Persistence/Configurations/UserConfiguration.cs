using Car.Rental.Domain.Users;
using Car.Rental.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car.Rental.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ConfigureAuditFields();

        builder.ToTable(nameof(User));

        builder.Property(x => x.FirstName)
            .HasMaxLength(UserConstants.FirstNameMaxLength);

        builder.Property(x => x.LastName)
            .HasMaxLength(UserConstants.LastNameMaxLength);

        builder.Property(x => x.Email)
            .HasMaxLength(UserConstants.EmailMaxLength);
    }
}