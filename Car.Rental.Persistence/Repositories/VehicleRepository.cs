using Car.Rental.Domain.Vehicles;

namespace Car.Rental.Persistence.Repositories;

internal sealed class VehicleRepository(CrDbContext dbContext) : Repository<Vehicle>(dbContext), IVehicleRepository;