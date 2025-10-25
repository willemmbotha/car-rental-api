using Car.Rental.Domain.Shared.Search;
using Car.Rental.Domain.Vehicles;
using FastEndpoints;

namespace Car.Rental.Application.Features.Vehicles.Search;

public class Endpoint(IVehicleRepository vehicleRepository) : Endpoint<SearchRequest, SearchResponse<VehicleDto>>
{
    public override void Configure()
    {
        Post("/search");
        Group<VehicleGroup>();
    }

    public override async Task HandleAsync(SearchRequest req, CancellationToken ct)
    {
        var result = await vehicleRepository.SearchAsync<VehicleDto>(req, ct);
        await Send.OkAsync(result, ct);
    }
}