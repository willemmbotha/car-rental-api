using Car.Rental.Domain.Vehicles;
using Car.Rental.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car.Rental.Persistence.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ConfigureAuditFields();

        builder.ToTable(nameof(Vehicle));

        builder.Property(x => x.DisplayName)
            .HasMaxLength(VehicleConstants.DisplayNameMaxLength);

        builder.Property(x => x.RegistrationNumber)
            .HasMaxLength(VehicleConstants.RegistrationNumberMaxLength);

        builder.Property(x => x.Year);

        builder.Property(x => x.Make)
            .HasMaxLength(VehicleConstants.MakeMaxLength);

        builder.Property(x => x.Model)
            .HasMaxLength(VehicleConstants.ModelMaxLength);

        builder.Property(x => x.Mileage);

        builder.Property(x => x.FuelType)
            .HasConversion<string>()
            .HasMaxLength(VehicleConstants.FuelTypeMaxLength);

        builder.Property(x => x.LicenseExpiryDate);

        builder.Property(x => x.VehicleStatus)
            .HasConversion<string>()
            .HasMaxLength(VehicleConstants.VehicleStatusMaxLength);

        builder.Property(x => x.PhotoUrl)
            .HasMaxLength(VehicleConstants.PhotoUrlMaxLength);

        builder.Property(x => x.RentalPrice);
    }
}