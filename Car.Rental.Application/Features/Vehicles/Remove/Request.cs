namespace Car.Rental.Application.Features.Vehicles.Remove;

public sealed record Request
{
    public long VehicleId { get; init; }
}