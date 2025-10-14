namespace Car.Rental.Application.Features.Customers.Create;

public sealed record Request
{
    public string Name { get; init; } = null!;
}