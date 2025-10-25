namespace Car.Rental.Domain.Shared.UserContext;

public sealed class CurrentUserContext
{
    public string Email { get; set; } = null!;
    public string DescopeUserId { get; set; } = null!;
}