using Car.Rental.Domain.Rentals;
using FastEndpoints;

namespace Car.Rental.Application.Features.Rentals.Get;

public class Endpoint(IRentalRepository rentalRepository) : Endpoint<Request, RentalDto, Mapper>
{
    public override void Configure()
    {
        Get("/{rentalId}");
        Group<RentalGroup>();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var rental = await rentalRepository.GetByIdAsync(req.RentalId, ct);

        await Send.OkAsync(Map.FromEntity(rental), ct);
    }
}