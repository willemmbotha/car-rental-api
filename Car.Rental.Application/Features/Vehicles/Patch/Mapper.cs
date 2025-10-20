using Car.Rental.Domain.Vehicles;
using FastEndpoints;

namespace Car.Rental.Application.Features.Vehicles.Patch;

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

    public override Vehicle UpdateEntity(Request r, Vehicle e)
    {
        e.FuelType = r.FuelType ?? e.FuelType;
        e.VehicleStatus = r.VehicleStatus ?? e.VehicleStatus;
        e.LicenseExpiryDate = r.LicenseExpiryDate ?? e.LicenseExpiryDate;
        e.Make = r.Make ?? e.Make;
        e.Mileage = r.Mileage ?? e.Mileage;
        e.Model = r.Model ?? e.Model;
        e.Year = r.Year ?? e.Year;
        e.DisplayName = r.DisplayName ?? e.DisplayName;
        e.RegistrationNumber = r.RegistrationNumber ?? e.RegistrationNumber;
        return e;
    }
}