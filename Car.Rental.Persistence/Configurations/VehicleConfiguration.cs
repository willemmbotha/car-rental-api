using Car.Rental.Domain.Vehicles;
using Car.Rental.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car.Rental.Persistence.Configurations;

public class VehicleConfiguration: IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ConfigureAuditFields();

        builder.ToTable(nameof(Vehicle));
    }
}