using Car.Rental.Application.Shared.Extensions;
using Car.Rental.Application.Shared.Search;
using Car.Rental.Persistence;
using FastEndpoints;

namespace Car.Rental.Application.Features.Rentals.Search;

public class Endpoint : Endpoint<SearchRequest, SearchResponse<RentalDto>>
{
    private readonly CrDbContext _crDbContext;

    public Endpoint(CrDbContext crDbContext)
    {
        _crDbContext = crDbContext;
    }

    public override void Configure()
    {
        Post("/search");
        Group<RentalGroup>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(SearchRequest req, CancellationToken ct)
    {
        var result = await _crDbContext.Rentals
            .Select(x => new RentalDto
            {
                Id = x.Id
            })
            .SearchAsync(req, ct);

        await Send.OkAsync(result, ct);
    }
}