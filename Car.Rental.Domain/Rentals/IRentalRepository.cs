using Car.Rental.Domain.Shared;
using Car.Rental.Domain.Shared.Search;

namespace Car.Rental.Domain.Rentals;

public interface IRentalRepository : IRepository<Rental>
{
    Task<SearchResponse<Rental>> SearchRentalsAsync(SearchRequest request, CancellationToken ct);
}