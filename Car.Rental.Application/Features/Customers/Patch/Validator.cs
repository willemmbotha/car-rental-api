using Car.Rental.Domain.Customers;
using FastEndpoints;
using FluentValidation;

namespace Car.Rental.Application.Features.Customers.Patch;

public class Validator : Validator<Request>
{
    public Validator()
    {
        When(x => x.FirstName != null, () =>
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(CustomerConstants.FirstNameMaxLength);
        });

        When(x => x.LastName != null, () =>
        {
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(CustomerConstants.LastNameMaxLength);
        });

        When(x => x.Email != null, () =>
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(CustomerConstants.EmailMaxLength);
        });

        When(x => x.Address != null, () =>
        {
            RuleFor(x => x.Address)
                .NotEmpty()
                .MaximumLength(CustomerConstants.AddressMaxLength);
        });

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