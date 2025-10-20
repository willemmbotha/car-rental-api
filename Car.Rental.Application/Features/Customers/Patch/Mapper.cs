using Car.Rental.Domain.Customers;
using FastEndpoints;

namespace Car.Rental.Application.Features.Customers.Patch;

public sealed class Mapper : Mapper<Request, CustomerDto, Customer>
{
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

    public override Customer UpdateEntity(Request r, Customer e)
    {
        e.Address = r.Address ?? e.Address;
        e.FirstName = r.FirstName ?? e.FirstName;
        e.LastName = r.LastName ?? e.LastName;
        e.Email = r.Email ?? e.Email;

        return e;
    }
}