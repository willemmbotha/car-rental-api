using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace Car.Rental.Application.Features.Vehicles;

public sealed class VehicleGroup : Group
{
    public VehicleGroup()
    {
        Configure("vehicle", ep =>
        {
            ep.Description(x => x
                .WithTags("Vehicle"));
        });
    }
}