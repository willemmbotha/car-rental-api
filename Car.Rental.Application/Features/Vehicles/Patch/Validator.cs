using Car.Rental.Domain.Vehicles;
using Car.Rental.Persistence;
using FastEndpoints;
using FluentValidation;

namespace Car.Rental.Application.Features.Vehicles.Patch;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.VehicleId)
            .NotNull()
            .Must(VehicleMustExist)
            .WithMessage("Vehicle does not exist");

        When(x => x.DisplayName != null, () =>
        {
            RuleFor(x => x.DisplayName)
                .NotEmpty()
                .MaximumLength(VehicleConstants.DisplayNameMaxLength);
        });

        When(x => x.RegistrationNumber != null, () =>
        {
            RuleFor(x => x.RegistrationNumber)
                .NotEmpty()
                .MaximumLength(VehicleConstants.RegistrationNumberMaxLength);
        });

        When(x => x.Year != null, () =>
        {
            RuleFor(x => x.Year)
                .NotNull()
                .InclusiveBetween(1886, DateTime.UtcNow.Year + 1);
        });

        When(x => x.Make != null, () =>
        {
            RuleFor(x => x.Make)
                .NotEmpty()
                .MaximumLength(VehicleConstants.MakeMaxLength);
        });

        When(x => x.Model != null, () =>
        {
            RuleFor(x => x.Model)
                .NotEmpty()
                .MaximumLength(VehicleConstants.ModelMaxLength);
        });

        When(x => x.Mileage != null, () =>
        {
            RuleFor(x => x.Mileage)
                .NotNull()
                .GreaterThanOrEqualTo(0);
        });

        When(x => x.FuelType != null, () =>
        {
            RuleFor(x => x.FuelType)
                .IsInEnum()
                .WithMessage("Invalid fuel type specified.");
        });

        When(x => x.LicenseExpiryDate != null, () =>
        {
            RuleFor(x => x.LicenseExpiryDate)
                .NotNull()
                .GreaterThan(DateTimeOffset.UtcNow)
                .WithMessage("License expiry date must be in the future.");
        });

        When(x => x.LicenseExpiryDate != null, () =>
        {
            RuleFor(x => x.VehicleStatus)
                .IsInEnum()
                .WithMessage("Invalid vehicle status specified.");
        });
    }

    private bool VehicleMustExist(long id)
    {
        return Resolve<CrDbContext>()
            .Vehicles
            .Any(x => x.Id == id);
    }
}