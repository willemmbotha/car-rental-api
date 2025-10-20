using Car.Rental.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Application.Features.Vehicles.Get;

public class Endpoint : Endpoint<Request, VehicleDto, Mapper>
{
    private readonly CrDbContext _crDbContext;

    public Endpoint(CrDbContext crDbContext)
    {
        _crDbContext = crDbContext;
    }

    public override void Configure()
    {
        Get("/{vehicleId}");
        Group<VehicleGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var vehicle = await _crDbContext.Vehicles
            .SingleAsync(x => x.Id == req.VehicleId, ct);

        await Send.OkAsync(Map.FromEntity(vehicle), ct);
    }
}