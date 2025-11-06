using Car.Rental.Domain.Vehicles;
using FastEndpoints;

namespace Car.Rental.Application.Features.Vehicles.Create;

public sealed class Mapper : Mapper<Request, VehicleDto, Vehicle>
{
    public override Vehicle ToEntity(Request r)
    {
        return new Vehicle
        {
            FuelType = r.FuelType,
            VehicleStatus = r.VehicleStatus,
            LicenseExpiryDate = r.LicenseExpiryDate,
            Make = r.Make,
            Mileage = r.Mileage,
            Model = r.Model,
            Year = r.Year,
            DisplayName = r.DisplayName,
            RegistrationNumber = r.RegistrationNumber,
            PhotoUrl = r.PhotoUrl,
            RentalPrice = r.RentalPrice,
        };
    }

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
            RegistrationNumber = e.RegistrationNumber,
            PhotoUrl = e.PhotoUrl,
            RentalPrice = e.RentalPrice
        };
    }
}