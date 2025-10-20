using Car.Rental.Persistence;
using FastEndpoints;
using FluentValidation;

namespace Car.Rental.Application.Features.Customers.Get;

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
        return Resolve<CrDbContext>()
            .Customers
            .Any(x => x.Id == id);
    }
}