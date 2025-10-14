using Car.Rental.Domain.Rentals;
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

        builder.HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId);
        
        builder.HasOne(x => x.Vehicle)
            .WithMany()
            .HasForeignKey(x => x.VehicleId);

        builder.Property(x => x.StartDate);
        
        builder.Property(x => x.EndDate);
        
        builder.Property(x => x.RentalStatus)
            .HasConversion<string>()
            .HasMaxLength(RentalConstants.RentalStatusMaxLength);
    }
}