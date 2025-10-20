namespace Car.Rental.Application.Features.Customers.Create;

public sealed record Request
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Address { get; init; } = null!;
}