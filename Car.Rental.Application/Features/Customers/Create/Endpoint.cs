using Car.Rental.Domain.Customers;
using FastEndpoints;

namespace Car.Rental.Application.Features.Customers.Create;

public class Endpoint(ICustomerRepository repository) : Endpoint<Request, CustomerDto, Mapper>
{
    public override void Configure()
    {
        Post("create");
        Group<CustomerGroup>();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var customer = Map.ToEntity(req);
        await repository.AddAsync(customer, ct);
        await repository.SaveChangesAsync(ct);
        await Send.OkAsync(Map.FromEntity(customer), ct);
    }
}