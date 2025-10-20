namespace Car.Rental.Application.Features.Rentals.Get;

public sealed record Request
{
    public long RentalId { get; init; }
}