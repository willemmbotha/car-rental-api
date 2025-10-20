using Car.Rental.Persistence;
using FastEndpoints;

namespace Car.Rental.Application.Features.Customers.Create;

public class Endpoint : Endpoint<Request, CustomerDto, Mapper>
{
    private readonly CrDbContext _crDbContext;

    public Endpoint(CrDbContext crDbContext)
    {
        _crDbContext = crDbContext;
    }

    public override void Configure()
    {
        Post("create");
        Group<CustomerGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var customer = Map.ToEntity(req);
        _crDbContext.Customers.Add(customer);
        await _crDbContext.SaveChangesAsync(ct);
        await Send.OkAsync(Map.FromEntity(customer), ct);
    }
}