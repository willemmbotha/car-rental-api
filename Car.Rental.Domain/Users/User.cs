using Car.Rental.Domain.Shared;

namespace Car.Rental.Domain.Users;
 
public sealed class User : AuditableEntity
{
    public string FirstName { get; set; } = null!;
    public  string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
}

public static class UserConstants
{
    public const int FirstNameMaxLength = 255;
    public const int LastNameMaxLength = 255;
    public const int EmailMaxLength = 320;
}