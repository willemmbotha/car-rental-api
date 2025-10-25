using System.Linq.Expressions;
using Car.Rental.Domain.Shared.Search;

namespace Car.Rental.Domain.Shared;

public interface IRepository<T> where T : AuditableEntity
{
    Task<T> GetByIdAsync(long id, CancellationToken ct);

    bool Any(Expression<Func<T, bool>> predicate);

    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct);

    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken ct);

    Task AddAsync(T entity, CancellationToken ct);

    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct);

    void Update(T entity);

    void Remove(T entity);

    void RemoveRange(IEnumerable<T> entities);

    Task<int> SaveChangesAsync(CancellationToken ct);

    Task<SearchResponse<TResponse>> SearchAsync<TResponse>(SearchRequest request, CancellationToken ct);

    Task<List<TResponse>> SearchNoCountAsync<TResponse>(SearchRequest request, CancellationToken ct);
}