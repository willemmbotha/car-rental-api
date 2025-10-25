using Car.Rental.Domain.Vehicles;
using FastEndpoints;
using FluentValidation;

namespace Car.Rental.Application.Features.Vehicles.Create;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.DisplayName)
            .NotEmpty()
            .MaximumLength(VehicleConstants.DisplayNameMaxLength);

        RuleFor(x => x.RegistrationNumber)
            .NotEmpty()
            .MaximumLength(VehicleConstants.RegistrationNumberMaxLength)
            .Must(RegistrationNumberMustNotExist)
            .WithMessage("Vehicle with registration number already exists.");

        RuleFor(x => x.Year)
            .NotNull()
            .InclusiveBetween(1886, DateTime.UtcNow.Year + 1);

        RuleFor(x => x.Make)
            .NotEmpty()
            .MaximumLength(VehicleConstants.MakeMaxLength);

        RuleFor(x => x.Model)
            .NotEmpty()
            .MaximumLength(VehicleConstants.ModelMaxLength);

        RuleFor(x => x.Mileage)
            .NotNull()
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.FuelType)
            .IsInEnum()
            .WithMessage("Invalid fuel type specified.");

        RuleFor(x => x.LicenseExpiryDate)
            .NotNull()
            .GreaterThan(DateTimeOffset.UtcNow)
            .WithMessage("License expiry date must be in the future.");

        RuleFor(x => x.VehicleStatus)
            .IsInEnum()
            .WithMessage("Invalid vehicle status specified.");
    }

    private bool RegistrationNumberMustNotExist(string registrationNumber)
    {
        return !Resolve<IVehicleRepository>().Any(x => x.RegistrationNumber == registrationNumber);
    }
}