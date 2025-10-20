using Car.Rental.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Application.Features.Rentals.Get;

public class Endpoint : Endpoint<Request, RentalDto, Mapper>
{
    private readonly CrDbContext _crDbContext;

    public Endpoint(CrDbContext crDbContext)
    {
        _crDbContext = crDbContext;
    }

    public override void Configure()
    {
        Get("/{rentalId}");
        Group<RentalGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var rental = await _crDbContext.Rentals
            .SingleAsync(x => x.Id == req.RentalId, ct);

        await Send.OkAsync(Map.FromEntity(rental), ct);
    }
}