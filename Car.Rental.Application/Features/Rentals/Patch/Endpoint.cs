using Car.Rental.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Application.Features.Rentals.Patch;

public class Endpoint : Endpoint<Request, RentalDto, Mapper>
{
    private readonly CrDbContext _crDbContext;

    public Endpoint(CrDbContext crDbContext)
    {
        _crDbContext = crDbContext;
    }

    public override void Configure()
    {
        Patch("/{rentalId}");
        Group<RentalGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var rental = await _crDbContext.Rentals
            .SingleAsync(x => x.Id == req.RentalId, ct);

        Map.UpdateEntity(req, rental);

        await _crDbContext.SaveChangesAsync(ct);

        await Send.OkAsync(Map.FromEntity(rental), ct);
    }
}