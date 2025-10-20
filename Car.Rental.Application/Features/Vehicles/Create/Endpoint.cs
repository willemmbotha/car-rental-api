using Car.Rental.Persistence;
using FastEndpoints;

namespace Car.Rental.Application.Features.Vehicles.Create;

public class Endpoint : Endpoint<Request, VehicleDto, Mapper>
{
    private readonly CrDbContext _crDbContext;

    public Endpoint(CrDbContext crDbContext)
    {
        _crDbContext = crDbContext;
    }

    public override void Configure()
    {
        Post("create");
        Group<VehicleGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var vehicle = Map.ToEntity(req);
        _crDbContext.Vehicles.Add(vehicle);
        await _crDbContext.SaveChangesAsync(ct);
        await Send.OkAsync(Map.FromEntity(vehicle), ct);
    }
}