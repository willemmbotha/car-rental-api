using Car.Rental.Persistence;
using FastEndpoints;
using FluentValidation;

namespace Car.Rental.Application.Features.Rentals.Remove;

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
        return Resolve<CrDbContext>()
            .Rentals
            .Any(x => x.Id == id);
    }
}