using Car.Rental.Domain.Users;

namespace Car.Rental.Persistence.Repositories;

internal sealed class UserRepository(CrDbContext dbContext) : Repository<User>(dbContext), IUserRepository;