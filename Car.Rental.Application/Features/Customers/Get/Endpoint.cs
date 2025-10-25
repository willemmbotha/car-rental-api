using Car.Rental.Domain.Customers;
using FastEndpoints;

namespace Car.Rental.Application.Features.Customers.Get;

public class Endpoint(ICustomerRepository repository) : Endpoint<Request, CustomerDto, Mapper>
{
    public override void Configure()
    {
        Get("/{customerId}");
        Group<CustomerGroup>();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var customer = await repository.GetByIdAsync(req.CustomerId, ct);
        await Send.OkAsync(Map.FromEntity(customer), ct);
    }
}