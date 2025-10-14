using FastEndpoints;
using FluentValidation;

namespace Car.Rental.Application.Features.Customers.Create;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}