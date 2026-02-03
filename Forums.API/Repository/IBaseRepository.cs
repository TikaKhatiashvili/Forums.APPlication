using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Forums.API.Repository;

public interface IBaseRepository<T, TContext> 
    where T : class where 
    TContext : DbContext 
{
    Task AddAsync(T entity);
    void Remove(T entity);  
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
    Task<int>SaveAsync(CancellationToken cancellationToken = default);  
    Task<bool> ExistsAsync(Expression<Func<T,bool>>predicate);
    Task<T>GetAsync(Expression<Func<T, bool>> filter, string includProperties,bool tracking=true);
    Task<(List<T> Items, int TotalCount)> GetAllAsync(
        Expression<Func<T, bool>> filter = null,
        int ? pageNumber=null,
        int? pageSize = null,
        string orderBy=null,
        bool ascending=true,
        string includeProperties = null,
        bool tracking = true
        );
}
