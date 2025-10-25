using Car.Rental.Domain.Customers;

namespace Car.Rental.Persistence.Repositories;

internal sealed class CustomerRepository(CrDbContext dbContext) : Repository<Customer>(dbContext), ICustomerRepository;