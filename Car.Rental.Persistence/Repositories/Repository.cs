using System.Linq.Expressions;
using Car.Rental.Domain.Shared;
using Car.Rental.Domain.Shared.Search;
using Car.Rental.Persistence.Shared.Exceptions;
using Gridify;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Persistence.Repositories;

public abstract class Repository<T>(CrDbContext context)
    where T : AuditableEntity
{
    private readonly CrDbContext _dbContext = context ?? throw new ArgumentNullException(nameof(context));

    public virtual async Task<T> GetByIdAsync(long id, CancellationToken ct)
    {
        return await _dbContext.Set<T>().SingleAsync(x => x.Id == id, ct);
    }

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken ct)
    {
        return await _dbContext.Set<T>().Where(predicate).ToListAsync();
    }

    public virtual async Task AddAsync(T entity, CancellationToken ct)
    {
        if (entity == null)
            throw new DomainException("Entity cannot be null.");

        await _dbContext.Set<T>().AddAsync(entity);
    }

    public virtual async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct)
    {
        await _dbContext.Set<T>().AddRangeAsync(entities, ct);
    }

    public virtual void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }

    public virtual void Remove(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _dbContext.Set<T>().RemoveRange(entities);
    }

    public virtual async Task<int> SaveChangesAsync(CancellationToken ct)
    {
        return await _dbContext.SaveChangesAsync(ct);
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct)
    {
        return await _dbContext.Set<T>().AnyAsync(predicate, ct);
    }

    public virtual bool Any(Expression<Func<T, bool>> predicate)
    {
        return _dbContext.Set<T>().Any(predicate);
    }

    public virtual async Task<SearchResponse<TResponse>> SearchAsync<TResponse>(SearchRequest request, CancellationToken ct)
    {
        var filters = request.Filters.Select(x => $"{x.PropertyName} {x.Operator} {x.Value} ");
        var filter = string.Join(request.LogicalOperator, filters);
        var order = string.Join(",", request.OrderBy
            .Select(x => $"{x.PropertyName} {x.Direction}")
            .ToList());

        // Aware that this could cause performance hits.
        var total = _dbContext.Set<T>().Count();

        var data = await _dbContext.Set<T>()
            .ApplyFiltering(filter)
            .ApplyOrdering(order)
            .ApplyPaging(request.Page, request.PageSize)
            .Select(x => x.Adapt<TResponse>())
            .ToListAsync(ct);

        return new SearchResponse<TResponse>
        {
            Data = data,
            Total = total
        };
    }

    public virtual async Task<List<TResponse>> SearchNoCountAsync<TResponse>(SearchRequest request, CancellationToken ct)
    {
        var filters = request.Filters.Select(x => $"{x.PropertyName} {x.Operator} {x.Value} ");
        var filter = string.Join(request.LogicalOperator, filters);
        var order = string.Join(",", request.OrderBy
            .Select(x => $"{x.PropertyName} {x.Direction}")
            .ToList());

        return await _dbContext.Set<T>()
            .ApplyFiltering(filter)
            .ApplyOrdering(order)
            .ApplyPaging(request.Page, request.PageSize)
            .Select(x => x.Adapt<TResponse>())
            .ToListAsync(ct);
    }
}