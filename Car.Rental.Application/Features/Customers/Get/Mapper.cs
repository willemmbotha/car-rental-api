using Car.Rental.Domain.Customers;
using FastEndpoints;

namespace Car.Rental.Application.Features.Customers.Get;

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
}