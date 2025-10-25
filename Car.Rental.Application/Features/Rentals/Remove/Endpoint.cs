using Car.Rental.Domain.Rentals;
using FastEndpoints;

namespace Car.Rental.Application.Features.Rentals.Remove;

public class Endpoint(IRentalRepository rentalRepository) : Endpoint<Request>
{
    public override void Configure()
    {
        Delete("/{rentalId}");
        Group<RentalGroup>();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var rental = await rentalRepository.GetByIdAsync(req.RentalId, ct);
        rentalRepository.Remove(rental);
        await rentalRepository.SaveChangesAsync(ct);
    }
}