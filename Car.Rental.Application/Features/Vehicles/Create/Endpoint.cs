using Car.Rental.Domain.Vehicles;
using FastEndpoints;

namespace Car.Rental.Application.Features.Vehicles.Create;

public class Endpoint(IVehicleRepository vehicleRepository) : Endpoint<Request, VehicleDto, Mapper>
{
    public override void Configure()
    {
        Post("create");
        Group<VehicleGroup>();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var vehicle = Map.ToEntity(req);
        await vehicleRepository.AddAsync(vehicle, ct);
        await vehicleRepository.SaveChangesAsync(ct);
        await Send.OkAsync(Map.FromEntity(vehicle), ct);
    }
}