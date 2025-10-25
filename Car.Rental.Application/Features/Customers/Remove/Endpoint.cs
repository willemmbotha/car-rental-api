using Car.Rental.Domain.Customers;
using FastEndpoints;

namespace Car.Rental.Application.Features.Customers.Remove;

public class Endpoint(ICustomerRepository repository) : Endpoint<Request>
{
    public override void Configure()
    {
        Delete("/{customerId}");
        Group<CustomerGroup>();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var customer = await repository.GetByIdAsync(req.CustomerId, ct);
        repository.Remove(customer);
        await repository.SaveChangesAsync(ct);
    }
}