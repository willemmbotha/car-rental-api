using Car.Rental.Application.Shared.Extensions;
using Car.Rental.Application.Shared.Search;
using Car.Rental.Persistence;
using FastEndpoints;

namespace Car.Rental.Application.Features.Customers.Search;

public class Endpoint : Endpoint<SearchRequest, SearchResponse<CustomerDto>>
{
    private readonly CrDbContext _crDbContext;

    public Endpoint(CrDbContext crDbContext)
    {
        _crDbContext = crDbContext;
    }

    public override void Configure()
    {
        Post("/search");
        Group<CustomerGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(SearchRequest req, CancellationToken ct)
    {
        var result = await _crDbContext.Customers
            .Select(x => new CustomerDto
            {
                Id = x.Id,
                Address = x.Address,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName
            })
            .SearchAsync(req, ct);

        await Send.OkAsync(result, ct);
    }
}