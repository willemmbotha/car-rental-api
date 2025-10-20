using Car.Rental.Persistence;
using FastEndpoints;
using FluentValidation;

namespace Car.Rental.Application.Features.Rentals.Create;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .Must(CustomerMustExist)
            .WithMessage("Customer does not exist.");

        RuleFor(x => x.VehicleId)
            .NotEmpty()
            .Must(VehicleMustExist)
            .WithMessage("Vehicle does not exist.");
            
        RuleFor(x => x.StartDate)
            .NotEmpty()
            .LessThan(x => x.EndDate)
            .WithMessage("Start date must be before the end date.");

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .GreaterThan(x => x.StartDate)
            .WithMessage("End date must be after the start date.");

        RuleFor(x => x.RentalStatus)
            .IsInEnum()
            .WithMessage("Invalid rental status specified.");
    }
    
    private bool VehicleMustExist(long id)
    {
        return Resolve<CrDbContext>()
            .Vehicles
            .Any(x => x.Id == id);
    }
    
    private bool CustomerMustExist(long id)
    {
        return Resolve<CrDbContext>()
            .Customers
            .Any(x => x.Id == id);
    }
}