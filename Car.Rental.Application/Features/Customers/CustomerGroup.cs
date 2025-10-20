using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace Car.Rental.Application.Features.Customers;

public sealed class CustomerGroup : Group
{
    public CustomerGroup()
    {
        Configure("customer", ep =>
        {
            ep.Description(x => x
                .WithTags("Customer"));
        });
    }
}