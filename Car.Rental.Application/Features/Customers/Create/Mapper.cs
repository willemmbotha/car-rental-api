using Car.Rental.Domain.Customers;
using FastEndpoints;

namespace Car.Rental.Application.Features.Customers.Create;

public sealed class Mapper : Mapper<Request, CustomerDto, Customer>
{
    public override Customer ToEntity(Request r)
    {
        return new Customer
        {
            Address = r.Address,
            FirstName = r.FirstName,
            LastName = r.LastName,
            Email = r.Email
        };
    }

    public override CustomerDto FromEntity(Customer e)
    {
        return new CustomerDto
        {
            Id = e.Id,
            Address = e.Address,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Email = e.Email
        };
    }
}