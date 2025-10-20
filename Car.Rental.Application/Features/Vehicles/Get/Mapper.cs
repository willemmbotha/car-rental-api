using Car.Rental.Domain.Vehicles;
using FastEndpoints;

namespace Car.Rental.Application.Features.Vehicles.Get;

public sealed class Mapper : Mapper<Request, VehicleDto, Vehicle>
{
    public override VehicleDto FromEntity(Vehicle e)
    {
        return new VehicleDto
        {
            Id = e.Id,
            FuelType = e.FuelType,
            VehicleStatus = e.VehicleStatus,
            LicenseExpiryDate = e.LicenseExpiryDate,
            Make = e.Make,
            Mileage = e.Mileage,
            Model = e.Model,
            Year = e.Year,
            DisplayName = e.DisplayName,
            RegistrationNumber = e.RegistrationNumber
        };
    }
}