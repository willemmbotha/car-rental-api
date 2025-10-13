using Car.Rental.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car.Rental.Persistence.Configurations;

public class RentalConfiguration: IEntityTypeConfiguration<Domain.Rentals.Rental>
{
    public void Configure(EntityTypeBuilder<Domain.Rentals.Rental> builder)
    {
        builder.ConfigureAuditFields();

        builder.ToTable(nameof(Rental));
    }
}