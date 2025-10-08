using FastEndpoints;

namespace Car.Rental.Application.Features.Customers.Create;

public class MyEndpoint : EndpointWithoutRequest<CustomerDto>
{
    public override void Configure()
    {
        Post("/api/user/create");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Send.OkAsync();
    }
}