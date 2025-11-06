using Car.Rental.Domain.Rentals;
using Car.Rental.Domain.Shared.Search;
using Gridify;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Persistence.Repositories;

internal sealed class RentalRepository(CrDbContext dbContext) : Repository<Domain.Rentals.Rental>(dbContext), IRentalRepository
{
    private readonly CrDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<SearchResponse<Domain.Rentals.Rental>> SearchRentalsAsync(SearchRequest request, CancellationToken ct)
    {
        var filters = request.Filters.Select(x => $"{x.PropertyName} {x.Operator} {x.Value} ");
        var filter = string.Join(request.LogicalOperator, filters);
        var order = string.Join(",", request.OrderBy
            .Select(x => $"{x.PropertyName} {x.Direction}")
            .ToList());

        // Aware that this could cause performance hits.
        var total = _dbContext.Rentals.Count();

        var data = await _dbContext.Rentals
            .Include(x => x.Customer)
            .Include(x => x.Vehicle)
            .ApplyFiltering(filter)
            .ApplyOrdering(order)
            .ApplyPaging(request.Page, request.PageSize)
            .ToListAsync(ct);

        return new SearchResponse<Domain.Rentals.Rental>
        {
            Data = data,
            Total = total
        };
    }
}