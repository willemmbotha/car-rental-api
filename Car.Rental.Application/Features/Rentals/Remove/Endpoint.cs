using Car.Rental.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Application.Features.Rentals.Remove;

public class Endpoint : Endpoint<Request>
{
    private readonly CrDbContext _crDbContext;

    public Endpoint(CrDbContext crDbContext)
    {
        _crDbContext = crDbContext;
    }

    public override void Configure()
    {
        Delete("/{rentalId}");
        Group<RentalGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var rental = await _crDbContext.Rentals
            .SingleAsync(x => x.Id == req.RentalId, ct);

        _crDbContext.Rentals.Remove(rental);
        await _crDbContext.SaveChangesAsync(ct);
    }
}