using Car.Rental.Domain.Shared;

namespace Car.Rental.Domain.Customers;

public sealed class Customer : AuditableEntity
{
    public string FirstName { get; set; } = null!;
    public  string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
}