using Car.Rental.Domain.Customers;
using FastEndpoints;
using FluentValidation;

namespace Car.Rental.Application.Features.Customers.Remove;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.CustomerId)
            .NotNull()
            .Must(CustomerMustExist)
            .WithMessage("Customer does not exist");
    }

    private bool CustomerMustExist(long id)
    {
        return Resolve<ICustomerRepository>().Any(x => x.Id == id);
    }
}