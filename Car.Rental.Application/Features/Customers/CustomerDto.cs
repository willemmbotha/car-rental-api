namespace Car.Rental.Application.Features.Customers;

public sealed record CustomerDto
{
    public long Id { get; init; }
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Address { get; init; } = null!;
}