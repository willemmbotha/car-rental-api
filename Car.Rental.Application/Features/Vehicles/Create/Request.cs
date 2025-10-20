﻿using Car.Rental.Domain.Vehicles;

namespace Car.Rental.Application.Features.Vehicles.Create;

public sealed record Request
{
    public string DisplayName { get; init; } = null!;
    public string RegistrationNumber { get; init; } = null!;
    public int Year { get; init; }
    public string Make { get; init; } = null!;
    public string Model { get; init; } = null!;
    public long Mileage { get; init; }
    public FuelType FuelType { get; init; }
    public DateTimeOffset LicenseExpiryDate { get; init; }
    public VehicleStatus VehicleStatus { get; init; }
}