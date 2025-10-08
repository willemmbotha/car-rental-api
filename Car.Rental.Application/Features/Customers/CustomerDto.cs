namespace Car.Rental.Application.Features.Customers;

public sealed record CustomerDto
{
    public string Name { get; init; } = null!;
}