using Car.Rental.Domain.Customers;
using FastEndpoints;

namespace Car.Rental.Application.Features.Customers.Patch;

public class Endpoint(ICustomerRepository repository) : Endpoint<Request, CustomerDto, Mapper>
{
    public override void Configure()
    {
        Patch("/{customerId}");
        Group<CustomerGroup>();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var customer = await repository.GetByIdAsync(req.CustomerId, ct);

        Map.UpdateEntity(req, customer);

        await repository.SaveChangesAsync(ct);

        await Send.OkAsync(Map.FromEntity(customer), ct);
    }
}