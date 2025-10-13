namespace Car.Rental.Domain.Rentals;

public enum RentalStatus
{
    New,
    Cancelled,
    Returned,
    Rented,
    Escalated,
    Stolen,
    AwaitingPickup
}