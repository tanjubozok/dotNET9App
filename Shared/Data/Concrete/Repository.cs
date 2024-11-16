using Microsoft.EntityFrameworkCore;
using Shared.Data.Abstract;
using Shared.Entities.Abstract;
using System.Linq.Expressions;

namespace Shared.Data.Concrete;

public class Repository<T>(DbContext context) : IRepository<T> where T : class, IEntity, new()
{
    private readonly DbContext _context = context;

    public async Task AddAsync(T entity)
        => await _context.Set<T>().AddAsync(entity);

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        => await _context.Set<T>().AnyAsync(predicate);

    public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        => await _context.Set<T>().CountAsync(predicate);

    public async Task DeleteAsync(T entity)
        => await Task.Run(() => { _context.Set<T>().Remove(entity); });

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _context.Set<T>();

        if (predicate != null)
            query = query.Where(predicate);

        query = includeProperties.Aggregate(query, (current, includeProperty)
            => current.Include(includeProperty));

        return await query.ToListAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _context.Set<T>();

        if (predicate != null)
            query = query.Where(predicate);

        query = includeProperties.Aggregate(query, (current, includeProperty)
            => current.Include(includeProperty));

        return await query.FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(T entity)
        => await Task.Run(() => { _context.Set<T>().Update(entity); });
}
