using Car.Rental.Persistence.Common.UserContext;
using Car.Rental.Persistence.Shared.Exceptions;
using FastEndpoints;

namespace Car.Rental.Application.Features.Customers.Create;

public class Endpoint : Endpoint<Request, CustomerDto, Mapper>
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

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        throw new DomainException();
        await Send.OkAsync();
    }
}