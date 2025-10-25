using Car.Rental.Domain.Rentals;
using FastEndpoints;
using FluentValidation;

namespace Car.Rental.Application.Features.Rentals.Get;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.RentalId)
            .NotNull()
            .Must(RentalMustExist)
            .WithMessage("Rental does not exist");
    }

    private bool RentalMustExist(long id)
    {
        return Resolve<IRentalRepository>().Any(x => x.Id == id);
    }
}