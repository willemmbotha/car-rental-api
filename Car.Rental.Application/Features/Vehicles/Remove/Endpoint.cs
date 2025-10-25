using Car.Rental.Domain.Vehicles;
using FastEndpoints;

namespace Car.Rental.Application.Features.Vehicles.Remove;

public class Endpoint(IVehicleRepository vehicleRepository) : Endpoint<Request>
{
    public override void Configure()
    {
        Delete("/{vehicleId}");
        Group<VehicleGroup>();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var vehicle = await vehicleRepository.GetByIdAsync(req.VehicleId, ct);
        vehicleRepository.Remove(vehicle);
        await vehicleRepository.SaveChangesAsync(ct);
    }
}