using Car.Rental.Domain.Customers;
using Car.Rental.Domain.Shared;
using Car.Rental.Domain.Vehicles;

namespace Car.Rental.Domain.Rentals;

public sealed class Rental : AuditableEntity
{
    private Customer? _customer;
    
    public long CustomerId { get;  set; }
    public Customer Customer {
        get => _customer ?? throw new InvalidOperationException("Uninitialized property: " + nameof(Customer));  
        set => _customer = value; 
    }
    
    private Vehicle? _vehicle;
    
    public long VehicleId { get;  set; }
    public Vehicle Vehicle {    
        get => _vehicle ?? throw new InvalidOperationException("Uninitialized property: " + nameof(Vehicle));  
        set => _vehicle = value; 
    }
    
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    
    public RentalStatus RentalStatus { get; set; } 
}