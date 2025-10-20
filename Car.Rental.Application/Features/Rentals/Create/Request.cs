using Car.Rental.Domain.Rentals;

namespace Car.Rental.Application.Features.Rentals.Create;

public sealed record Request
{
    public long CustomerId { get; init; }
    public long VehicleId { get; init; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public RentalStatus RentalStatus { get; set; }
}