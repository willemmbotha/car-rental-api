using Car.Rental.Domain.Customers;
using Car.Rental.Domain.Users;
using Car.Rental.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Persistence;

public class CrDbContext(DbContextOptions<CrDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Domain.Rentals.Rental> Rentals { get; set; }
}