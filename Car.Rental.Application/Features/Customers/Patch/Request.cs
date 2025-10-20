namespace Car.Rental.Application.Features.Customers.Patch;

public sealed record Request
{
    public long CustomerId { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public string? Address { get; init; }
}