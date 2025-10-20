using Car.Rental.Persistence;
using FastEndpoints;
using FluentValidation;

namespace Car.Rental.Application.Features.Rentals.Patch;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.RentalId)
            .NotNull()
            .Must(RentalMustExist)
            .WithMessage("Rental does not exist");

        When(x => x.CustomerId != 0, () =>
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .WithMessage("CustomerId must be a valid non-zero value.");
        });

        When(x => x.VehicleId != 0, () =>
        {
            RuleFor(x => x.VehicleId)
                .GreaterThan(0)
                .WithMessage("VehicleId must be a valid non-zero value.");
        });

        When(x => x.StartDate != default, () =>
        {
            RuleFor(x => x.StartDate)
                .NotEmpty()
                .LessThan(x => x.EndDate)
                .WithMessage("Start date must be before the end date.");
        });

        When(x => x.EndDate != default, () =>
        {
            RuleFor(x => x.EndDate)
                .NotEmpty()
                .GreaterThan(x => x.StartDate)
                .WithMessage("End date must be after the start date.");
        });

        When(x => x.RentalStatus != null, () =>
        {
            RuleFor(x => x.RentalStatus)
                .IsInEnum()
                .WithMessage("Invalid rental status specified.");
        });
    }

    private bool RentalMustExist(long id)
    {
        return Resolve<CrDbContext>()
            .Rentals
            .Any(x => x.Id == id);
    }
}