using Car.Rental.Domain.Rentals;
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
            .WithMessage("Rental does not exist")
            .MustAsync(MustBeFutureBooking)
            .WithMessage("Can only remove future bookings");
    }

    private bool RentalMustExist(long id)
    {
        return Resolve<IRentalRepository>().Any(x => x.Id == id);
    }

    private async Task<bool> MustBeFutureBooking(long id, CancellationToken ct)
    {
        var rental = await Resolve<IRentalRepository>().GetByIdAsync(id, ct);
        return rental.StartDate > DateTimeOffset.UtcNow;
    }
}