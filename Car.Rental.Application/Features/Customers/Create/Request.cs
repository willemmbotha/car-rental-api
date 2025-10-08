namespace Car.Rental.Application.Features.Customers.Create;

public record Request
{
    public string Name { get; init; } = null!;
}