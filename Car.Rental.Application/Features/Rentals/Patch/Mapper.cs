using FastEndpoints;

namespace Car.Rental.Application.Features.Rentals.Patch;

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

    public override Domain.Rentals.Rental UpdateEntity(Request r, Domain.Rentals.Rental e)
    {
        e.CustomerId = r.CustomerId ?? e.CustomerId;
        e.VehicleId = r.VehicleId ?? e.VehicleId;
        e.EndDate = r.EndDate ?? e.EndDate;
        e.RentalStatus = r.RentalStatus ?? e.RentalStatus;
        e.StartDate = r.StartDate ?? e.StartDate;
        return e;
    }
}