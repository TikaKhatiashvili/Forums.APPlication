using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Forums.API.Repository;

public class BaseRepository<T, TContext> : IBaseRepository<T, TContext> where T : class where TContext : DbContext
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;
    public BaseRepository(TContext context)
    {
        _context = context;//ბაზა
        _dbSet = _context.Set<T>();//მიბრუნებს ნებსმიერ DbSet - ს //ცხრილი
    }
    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
    public async Task<int> SaveAsync(CancellationToken cancellationToken = default) => await _context.SaveChangesAsync(cancellationToken);
    public void Remove(T entity) => _dbSet.Remove(entity);
    public void RemoveRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);
    public void Update(T entity) => _dbSet.Update(entity);

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate) => await _dbSet.AnyAsync(predicate);

    public async Task<(List<T> Items, int TotalCount)> GetAllAsync(
        Expression<Func<T,bool>> filter = null,
        int? pageNumber = null,
        int? pageSize = null,
        string orderBy = null,
        bool ascending = true,
        string includeProperties = null,
        bool tracking = true)
    {
        IQueryable<T> query = _dbSet;

        if (!tracking)
            query = query.AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        if (!string.IsNullOrWhiteSpace(includeProperties))
            query = ApplyIncludes(query, includeProperties);

        int totalCount = await query.CountAsync();

        if (!string.IsNullOrWhiteSpace(orderBy))
            query = ApplyIncludes(orderBy, ascending, query);

        if (pageNumber.HasValue && pageSize.HasValue)
        {
            int skip = (pageNumber.Value - 1) * pageSize.Value;
            query = query.Skip(skip).Take(pageSize.Value);
        }
        var items = await query.ToListAsync();
        return (items, totalCount);
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> filter, string includeProperties = null, bool tracking = true)//dbset დამყავს IQueryable<T> მდე
    {
        IQueryable<T> query = _dbSet.Where(filter);
        if (!tracking)
        {
            query = query.AsNoTracking();
        }

        query = ApplyIncludes(query, includeProperties);
        return await query.FirstOrDefaultAsync();
    }
    private static IQueryable<T> ApplyIncludes(string orderBy, bool ascending, IQueryable<T> query)//ბაზიდან მომაქვს ჩანაწერი და მათ ვალაგებთ თარიღის მიხედვით, ამისთვის ვიყებთ რეფლექშენს | თუ გადმომცემენ  bool ascending - True ალაგებს ან False კლებადობით
    {
        var propertyInfo = typeof(T).GetProperty(orderBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
    if(propertyInfo != null)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var propertyAccess = Expression.MakeMemberAccess(parameter, propertyInfo);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var methodName= "OrderBy";//ზრდადობით
            if (!ascending)
            {
                methodName = "OrderByDescending";//კლებადობით
            }
            var resultExpression = Expression.Call(
                typeof(Queryable), 
                methodName, 
                new Type[] { typeof(T), propertyInfo.PropertyType }, 
                query.Expression, 
                Expression.Quote(orderByExpression));
            query = query.Provider.CreateQuery<T>(resultExpression);
        }
        return query;


    }
    private static IQueryable<T> ApplyIncludes(IQueryable<T> query, string includeProperties)
    {
        if (!string.IsNullOrWhiteSpace(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty.Trim());
            }
        }
        return query;
    }
}
