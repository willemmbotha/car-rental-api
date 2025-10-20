using Car.Rental.Application.Shared.Search;
using Gridify;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Application.Shared.Extensions;

public static class SearchExtensions
{
    public static IQueryable<T> Search<T>(this IQueryable<T> query, SearchRequest request)
    {
        var filter = string.Join(request.LogicalOperator, request.Filters);
        var order = string.Join(",", request.OrderBy
            .Select(x => $"{x.PropertyName} {x.Direction}")
            .ToList());

        return query
            .ApplyFiltering(filter)
            .ApplyOrdering(order)
            .ApplyPaging(request.Page, request.PageSize);
    }

    public static async Task<SearchResponse<T>> SearchAsync<T>(this IQueryable<T> query, SearchRequest request,
        CancellationToken ctx)
        where T : class
    {
        var filter = string.Join(request.LogicalOperator, request.Filters);
        var order = string.Join(",", request.OrderBy
            .Select(x => $"{x.PropertyName} {x.Direction}")
            .ToList());

        var total = query.Count();
        var data = await query
            .ApplyFiltering(filter)
            .ApplyOrdering(order)
            .ApplyPaging(request.Page, request.PageSize)
            .ToListAsync(ctx);

        return new SearchResponse<T>
        {
            Data = data,
            Total = total
        };
    }
}