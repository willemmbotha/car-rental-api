using Car.Rental.Domain.Shared;

namespace Car.Rental.Domain.Customers;

public sealed class Customer : AuditableEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
}

public static class CustomerConstants
{
    public const int FirstNameMaxLength = 255;
    public const int LastNameMaxLength = 255;
    public const int EmailMaxLength = 320;
    public const int AddressMaxLength = 500;
}