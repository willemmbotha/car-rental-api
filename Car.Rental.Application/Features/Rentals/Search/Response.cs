using Car.Rental.Domain.Rentals;

namespace Car.Rental.Application.Features.Rentals.Search;

public sealed record Response
{
    public long Id { get; init; }
    public CustomerResponse Customer { get; init; } = null!;
    public VehicleResponse Vehicle { get; init; } = null!;
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public RentalStatus RentalStatus { get; set; }
}

public sealed record CustomerResponse
{
    public long Id { get; init; }
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
}

public sealed record VehicleResponse
{
    public long Id { get; init; }
    public string DisplayName { get; init; } = null!;
}