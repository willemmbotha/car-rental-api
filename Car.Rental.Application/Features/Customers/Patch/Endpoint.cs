using Car.Rental.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Application.Features.Customers.Patch;

public class Endpoint : Endpoint<Request, CustomerDto, Mapper>
{
    private readonly CrDbContext _crDbContext;

    public Endpoint(CrDbContext crDbContext)
    {
        _crDbContext = crDbContext;
    }

    public override void Configure()
    {
        Patch("/{customerId}");
        Group<CustomerGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var customer = await _crDbContext.Customers
            .SingleAsync(x => x.Id == req.CustomerId, ct);

        Map.UpdateEntity(req, customer);

        await _crDbContext.SaveChangesAsync(ct);

        await Send.OkAsync(Map.FromEntity(customer), ct);
    }
}