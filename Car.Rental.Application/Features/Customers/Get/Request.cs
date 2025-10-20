namespace Car.Rental.Application.Features.Customers.Get;

public sealed record Request
{
    public long CustomerId { get; init; }
}