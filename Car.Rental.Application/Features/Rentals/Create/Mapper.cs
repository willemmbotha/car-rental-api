using FastEndpoints;

namespace Car.Rental.Application.Features.Rentals.Create;

public sealed class Mapper : Mapper<Request, RentalDto, Domain.Rentals.Rental>
{
    public override Domain.Rentals.Rental ToEntity(Request r)
    {
        return new Domain.Rentals.Rental()
        {
            RentalStatus = r.RentalStatus,
            CustomerId = r.CustomerId,
            VehicleId = r.VehicleId,
            StartDate = r.StartDate,
            EndDate = r.StartDate
        };
    }

    public override RentalDto FromEntity(Domain.Rentals.Rental e)
    {
        return new RentalDto
        {
            Id = e.Id,
            CustomerId = e.CustomerId,
            VehicleId = e.VehicleId,
            EndDate = e.EndDate,
            RentalStatus = e.RentalStatus,
            StartDate = e.StartDate,
        };
    }
}