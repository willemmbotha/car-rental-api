using Car.Rental.Domain.Vehicles;

namespace Car.Rental.Application.Features.Vehicles.Patch;

public sealed record Request
{
    public long VehicleId { get; init; }
    public string? DisplayName { get; init; }
    public string? RegistrationNumber { get; init; }
    public int? Year { get; init; }
    public string? Make { get; init; }
    public string? Model { get; init; }
    public long? Mileage { get; init; }
    public FuelType? FuelType { get; init; }
    public DateTimeOffset? LicenseExpiryDate { get; init; }
    public VehicleStatus? VehicleStatus { get; init; }
    public string? PhotoUrl { get; init; }
    public decimal? RentalPrice { get; init; }
}