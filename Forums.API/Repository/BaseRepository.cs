using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Forums.API.Repository;

public class BaseRepository<T, TContext> : IBaseRepository<T, TContext> where T : class where TContext : DbContext
{
    public async Task AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<(List<T> Items, int TotalCount)> GetAllAsync(Expression<Func<T, bool>> filter = null, int? pageNumber = null, int? pageSize = null, string orderBy = null, bool ascending = true, string includeProperties = null, bool tracking = true)
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, string includProperties, bool tracking = true)
    {
        throw new NotImplementedException();
    }

    public async void Remove(T entity)
    {
        throw new NotImplementedException();
    }

    public async void RemoveRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async void Update(T entity)
    {
        throw new NotImplementedException();
    }
    //დრო 01:42:57
}
