using Car.Rental.Application.Shared.Extensions;
using Car.Rental.Application.Shared.Search;
using Car.Rental.Persistence;
using Car.Rental.Persistence.Common.UserContext;
using FastEndpoints;

namespace Car.Rental.Application.Features.Customers.Search;

public class Endpoint : Endpoint<SearchRequest, SearchResponse<CustomerDto>>
{
    private readonly CurrentUserContext _currentUserContext;
    private readonly CrDbContext _crDbContext;

    public Endpoint(CurrentUserContext currentUserContext, CrDbContext crDbContext)
    {
        _currentUserContext = currentUserContext;
        _crDbContext = crDbContext;
    }

    public override void Configure()
    {
        Post("/api/customer/search");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SearchRequest req, CancellationToken ct)
    {
        var result = await _crDbContext.Customers
            .Select(x => new CustomerDto()
            {
                Name = x.FirstName
            })
            .SearchAsync(req, ct);
        
        await Send.OkAsync(result, ct);
    }
}