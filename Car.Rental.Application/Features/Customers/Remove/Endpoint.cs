using Car.Rental.Persistence;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Application.Features.Customers.Remove;

public class Endpoint : Endpoint<Request>
{
    private readonly CrDbContext _crDbContext;

    public Endpoint(CrDbContext crDbContext)
    {
        _crDbContext = crDbContext;
    }

    public override void Configure()
    {
        Delete("/{customerId}");
        Group<CustomerGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var customer = await _crDbContext.Customers
            .SingleAsync(x => x.Id == req.CustomerId, ct);

        _crDbContext.Customers.Remove(customer);
        await _crDbContext.SaveChangesAsync(ct);
    }
}