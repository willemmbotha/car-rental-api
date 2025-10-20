using Car.Rental.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Application.Features.Vehicles.Remove;

public class Endpoint : Endpoint<Request>
{
    private readonly CrDbContext _crDbContext;

    public Endpoint(CrDbContext crDbContext)
    {
        _crDbContext = crDbContext;
    }

    public override void Configure()
    {
        Delete("/{vehicleId}");
        Group<VehicleGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var vehicle = await _crDbContext.Vehicles
            .SingleAsync(x => x.Id == req.VehicleId, ct);

        _crDbContext.Vehicles.Remove(vehicle);
        await _crDbContext.SaveChangesAsync(ct);
    }
}