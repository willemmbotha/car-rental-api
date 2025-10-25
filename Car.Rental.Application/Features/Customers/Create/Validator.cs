using Car.Rental.Domain.Customers;
using FastEndpoints;
using FluentValidation;

namespace Car.Rental.Application.Features.Customers.Create;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(CustomerConstants.FirstNameMaxLength);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(CustomerConstants.LastNameMaxLength);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(CustomerConstants.EmailMaxLength)
            .Must(EmailAddressMustNotExist)
            .WithMessage("Customer with email address already exists");

        RuleFor(x => x.Address)
            .NotEmpty()
            .MaximumLength(CustomerConstants.AddressMaxLength);
    }

    private bool EmailAddressMustNotExist(string email)
    {
        return !Resolve<ICustomerRepository>().Any(x => x.Email == email);
    }
}