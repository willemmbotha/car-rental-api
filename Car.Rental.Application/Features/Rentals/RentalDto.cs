using Car.Rental.Domain.Rentals;

namespace Car.Rental.Application.Features.Rentals;

public sealed record RentalDto
{
    public long Id { get; init; }
    public long CustomerId { get; init; }
    public long VehicleId { get; init; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public RentalStatus RentalStatus { get; set; }
}