using Car.Rental.Domain.Shared;

namespace Car.Rental.Domain.Vehicles;

public sealed class Vehicle: AuditableEntity
{
    public string DisplayName { get; set; } = null!;
    public string RegistrationNumber { get; set; } = null!;
    public int Year { get; set; }
    public string Make { get; set; } = null!;
    public string Model { get; set; } = null!;
    public long Mileage { get; set; }
    public FuelType FuelType { get; set; }
    public DateTimeOffset LicenseExpiryDate { get; set; }
    public VehicleStatus VehicleStatus { get; set; }
}