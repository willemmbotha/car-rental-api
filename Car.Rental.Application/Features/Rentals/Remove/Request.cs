namespace Car.Rental.Application.Features.Rentals.Remove;

public sealed record Request
{
    public long RentalId { get; init; }
}