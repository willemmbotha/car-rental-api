using Car.Rental.Application.Shared.Extensions;
using Car.Rental.Application.Shared.Search;
using Car.Rental.Persistence;
using FastEndpoints;

namespace Car.Rental.Application.Features.Vehicles.Search;

public class Endpoint : Endpoint<SearchRequest, SearchResponse<VehicleDto>>
{
    private readonly CrDbContext _crDbContext;

    public Endpoint(CrDbContext crDbContext)
    {
        _crDbContext = crDbContext;
    }

    public override void Configure()
    {
        Post("/search");
        Group<VehicleGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(SearchRequest req, CancellationToken ct)
    {
        var result = await _crDbContext.Vehicles
            .Select(x => new VehicleDto
            {
                Id = x.Id,
                FuelType = x.FuelType,
                VehicleStatus = x.VehicleStatus,
                LicenseExpiryDate = x.LicenseExpiryDate,
                Make = x.Make,
                Mileage = x.Mileage,
                Model = x.Model,
                Year = x.Year,
                DisplayName = x.DisplayName,
                RegistrationNumber = x.RegistrationNumber
            })
            .SearchAsync(req, ct);

        await Send.OkAsync(result, ct);
    }
}