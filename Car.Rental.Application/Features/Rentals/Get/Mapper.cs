using FastEndpoints;

namespace Car.Rental.Application.Features.Rentals.Get;

public sealed class Mapper : Mapper<Request, RentalDto, Domain.Rentals.Rental>
{
    public override RentalDto FromEntity(Domain.Rentals.Rental e)
    {
        return new RentalDto
        {
            Id = e.Id,
            CustomerId = e.CustomerId,
            VehicleId = e.VehicleId,
            EndDate = e.EndDate,
            RentalStatus = e.RentalStatus,
            StartDate = e.StartDate
        };
    }
}