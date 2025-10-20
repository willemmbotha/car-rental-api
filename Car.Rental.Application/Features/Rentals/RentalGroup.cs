using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace Car.Rental.Application.Features.Rentals;

public sealed class RentalGroup : Group
{
    public RentalGroup()
    {
        Configure("rental", ep =>
        {
            ep.Description(x => x
                .WithTags("Rental"));
        });
    }
}