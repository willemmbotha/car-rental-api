using Car.Rental.Domain.Customers;
using FastEndpoints;

namespace Car.Rental.Application.Features.Customers.Create;

public sealed class Mapper : Mapper<Request, CustomerDto, Customer>
{
    public override Customer ToEntity(Request r) => new()
    {
        
    };

    public override CustomerDto FromEntity(Customer e) => new()
    {
        
    };
}
