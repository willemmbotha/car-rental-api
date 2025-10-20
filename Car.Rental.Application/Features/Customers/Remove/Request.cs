namespace Car.Rental.Application.Features.Customers.Remove;

public sealed record Request
{
    public long CustomerId { get; init; }
}