using Car.Rental.Domain.Customers;
using Car.Rental.Domain.Rentals;
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

        RuleFor(x => x)
            .Must(CustomerMustNotHaveRentals)
            .WithMessage("Cannot delete customer with rentals");
    }

    private bool CustomerMustExist(long id)
    {
        return Resolve<ICustomerRepository>().Any(x => x.Id == id);
    }

    private bool CustomerMustNotHaveRentals(Request request)
    {
        return !Resolve<IRentalRepository>().Any(x => x.CustomerId == request.CustomerId);
    }
}