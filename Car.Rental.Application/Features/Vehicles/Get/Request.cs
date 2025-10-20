namespace Car.Rental.Application.Features.Vehicles.Get;

public sealed record Request
{
    public long VehicleId { get; init; }
}