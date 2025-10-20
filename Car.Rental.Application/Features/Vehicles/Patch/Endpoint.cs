using Car.Rental.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Application.Features.Vehicles.Patch;

public class Endpoint : Endpoint<Request, VehicleDto, Mapper>
{
    private readonly CrDbContext _crDbContext;

    public Endpoint(CrDbContext crDbContext)
    {
        _crDbContext = crDbContext;
    }

    public override void Configure()
    {
        Patch("/{vehicleId}");
        Group<VehicleGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var vehicle = await _crDbContext.Vehicles
            .SingleAsync(x => x.Id == req.VehicleId, ct);

        Map.UpdateEntity(req, vehicle);

        await _crDbContext.SaveChangesAsync(ct);

        await Send.OkAsync(Map.FromEntity(vehicle), ct);
    }
}