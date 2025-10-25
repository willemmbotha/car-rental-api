using Car.Rental.Domain.Vehicles;
using FastEndpoints;
using FluentValidation;

namespace Car.Rental.Application.Features.Vehicles.Remove;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.VehicleId)
            .NotNull()
            .Must(VehicleMustExist)
            .WithMessage("Vehicle does not exist");
    }

    private bool VehicleMustExist(long id)
    {
        return Resolve<IVehicleRepository>().Any(x => x.Id == id);
    }
}