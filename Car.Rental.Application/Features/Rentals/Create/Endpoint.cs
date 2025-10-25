using Car.Rental.Domain.Rentals;
using FastEndpoints;

namespace Car.Rental.Application.Features.Rentals.Create;

public class Endpoint(IRentalRepository rentalRepository) : Endpoint<Request, RentalDto, Mapper>
{
    public override void Configure()
    {
        Post("create");
        Group<RentalGroup>();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var rental = Map.ToEntity(req);

        await rentalRepository.AddAsync(rental, ct);
        await rentalRepository.SaveChangesAsync(ct);

        await Send.OkAsync(Map.FromEntity(rental), ct);
    }
}