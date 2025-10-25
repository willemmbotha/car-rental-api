using Car.Rental.Domain.Vehicles;
using FastEndpoints;

namespace Car.Rental.Application.Features.Vehicles.Get;

public class Endpoint(IVehicleRepository vehicleRepository) : Endpoint<Request, VehicleDto, Mapper>
{
    public override void Configure()
    {
        Get("/{vehicleId}");
        Group<VehicleGroup>();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var vehicle = await vehicleRepository.GetByIdAsync(req.VehicleId, ct);

        await Send.OkAsync(Map.FromEntity(vehicle), ct);
    }
}