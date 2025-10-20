using Car.Rental.Persistence;
using FastEndpoints;

namespace Car.Rental.Application.Features.Rentals.Create;

public class Endpoint : Endpoint<Request, RentalDto, Mapper>
{
    private readonly CrDbContext _crDbContext;

    public Endpoint(CrDbContext crDbContext)
    {
        _crDbContext = crDbContext;
    }

    public override void Configure()
    {
        Post("create");
        Group<RentalGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var rental = Map.ToEntity(req);
        
        _crDbContext.Rentals.Add(rental);
        await _crDbContext.SaveChangesAsync(ct);
        
        await Send.OkAsync(Map.FromEntity(rental), ct);
    }
}