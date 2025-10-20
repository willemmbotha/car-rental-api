using Car.Rental.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Application.Features.Customers.Get;

public class Endpoint : Endpoint<Request, CustomerDto, Mapper>
{
    private readonly CrDbContext _crDbContext;

    public Endpoint(CrDbContext crDbContext)
    {
        _crDbContext = crDbContext;
    }

    public override void Configure()
    {
        Get("/{customerId}");
        Group<CustomerGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var customer = await _crDbContext.Customers
            .SingleAsync(x => x.Id == req.CustomerId, ct);

        await Send.OkAsync(Map.FromEntity(customer), ct);
    }
}