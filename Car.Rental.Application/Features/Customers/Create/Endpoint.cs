using Car.Rental.Application.Common.Shared;
using FastEndpoints;

namespace Car.Rental.Application.Features.Customers.Create;

public class Endpoint : EndpointWithoutRequest<CustomerDto>
{
    private readonly CurrentUserContext _currentUserContext;

    public Endpoint(CurrentUserContext currentUserContext)
    {
        _currentUserContext = currentUserContext;
    }

    public override void Configure()
    {
        Post("/api/user/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Send.OkAsync();
    }
}