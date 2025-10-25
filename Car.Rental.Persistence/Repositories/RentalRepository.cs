using Car.Rental.Domain.Rentals;

namespace Car.Rental.Persistence.Repositories;

internal sealed class RentalRepository(CrDbContext dbContext) : Repository<Domain.Rentals.Rental>(dbContext), IRentalRepository;