using FundacionAMA.Domain.Interfaces.Repositories;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using FundacionAMA.Domain.Shared.Extensions.DataExtension;
using FundacionAMA.Domain.Shared.Interfaces;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using System.Linq.Expressions;

namespace FundacionAMA.Infrastructure.Persistence.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
{
    private readonly AMADbContext _context;

    private bool disposedValue;

    public BaseRepository(AMADbContext context)
    {
        _context = context;
    }

    public IQueryable<T> All => _context.Set<T>();
    public Task DeleteAsync(T entity)
    {
        _ = _context.Entry(entity).SetProperty("IdEstado", false);
        _ = _context.Entry(entity).SetProperty("Active", false);
        return UpdateAsync(entity);
    }


    public void Detach(T entity)
    {
        _context.Entry(entity).State = EntityState.Detached;
    }

    public Task DetachAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Detached;
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public bool Exists(Expression<Func<T, bool>> expression)
    {
        return AsQueryable().Any(expression);
    }

    public Task<bool> ExistsAscyn(Expression<Func<T, bool>> expression)
    {
        return AsQueryable().AnyAsync(expression);
    }

    public T First(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        return PerformInclusions(include).First(expression);
    }

    public Task<T> FirstAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        return PerformInclusions(include).FirstAsync(expression);
    }
    public T? FirstOrDefault(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        return PerformInclusions(include).FirstOrDefault(expression);
    }

    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        return PerformInclusions(include).FirstOrDefaultAsync(expression);
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        return expression is null ? PerformInclusions(include).AsEnumerable()
            :
            PerformInclusions(include).Where(expression).AsEnumerable();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        IQueryable<T> query = PerformInclusions(include);
        return expression is null ? await query.ToListAsync() : await query.Where(expression).ToListAsync();
    }

    public IQueryable<T> GetAllQuerable(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        IQueryable<T> query = PerformInclusions(include);
        return expression is null ? query : query.Where(expression);
    }

    public async Task<IQueryable<T>> GetAllQueryableAsync(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        IQueryable<T> query = PerformInclusions(include);
        return await Task.FromResult(expression is null ? query : query.Where(expression));
    }

    public T? GetById(params object[] keyValues)
    {
        return _context.Set<T>().Find(keyValues);
    }

    public async Task<T?> GetByIdAsync(params object[] keyValues)
    {
        return await _context.Set<T>().FindAsync(keyValues);
    }

    public void Insert(T entity)
    {
        _ = _context.Add(entity);
    }

    public async Task InsertAsync(T entity)
    {
        _ = await _context.AddAsync(entity);
    }

    public IQueryable<T> OrderBy(params Expression<Func<T, object>>[] properties)
    {
        IQueryable<T> query = All;
        foreach (Expression<Func<T, object>> property in properties)
        {
            query = query.OrderBy(property);
        }
        return query;
    }

    public IQueryable<T> OrderByDesc(params Expression<Func<T, object>>[] properties)
    {
        IQueryable<T> query = All;
        foreach (Expression<Func<T, object>> property in properties)
        {
            query = All.OrderByDescending(property);
        }
        return query;
    }

    public void SaveChanges(IOperationRequest? request = null)
    {
        if (request is not null)
        {
            SetDatabefore(request);
        }

        _ = _context.SaveChanges();
    }

    public async Task SaveChangesAsync(IOperationRequest? request = null)
    {
        if (request is not null)
        {
            SetDatabefore(request);
        }
        _ = await _context.SaveChangesAsync(CancellationToken.None);
    }

    public async Task SaveChangesAsync()
    {
        _ = await _context.SaveChangesAsync(CancellationToken.None);
    }

    public IOperationResultList<T> ToResultListPaginated(
                     int Offset = 1,
                        int? Take = 10)
    {
        return All.ToResultList(Offset: Offset, Take: Take);
    }

    public IOperationResultList<TResult> ToResultListPaginated<TResult>(
         int Offset = 1,
                        int Take = 10) where TResult : class
    {
        return All.ToResultList<T, TResult>(Offset: Offset, Take: Take);
    }

    public Task<IOperationResultList<TResult>> ToResultListPaginatedAscyn<TResult>(int Offset = 1, int Take = 10) where TResult : class
    {
        return All.ToResultListAsync<T, TResult>(Offset: Offset, Take: Take);
    }



    public void Update(T entity)
    {
        _ = _context.Update(entity);
    }

    public Task UpdateAsync(T entity)
    {
        _ = _context.Update(entity);
        return Task.CompletedTask;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: eliminar el estado administrado (objetos administrados)
            }

            // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
            // TODO: establecer los campos grandes como NULL
            disposedValue = true;
        }
    }

    private IQueryable<T> AsQueryable()
    {
        return _context.Set<T>().AsQueryable();
    }

    private IQueryable<T> PerformInclusions(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include)
    {
        return include == null ? AsQueryable() : include(AsQueryable());
    }

    private void SetDatabefore(IOperationRequest request)
    {
        foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry in _context.ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Modified)
            {
                _ = entry.SetProperty("UpdatedAt", DateTime.UtcNow)
                    .SetProperty("UpdatedBy", request.Usuario?.IdUsuario ?? 0)
                    .SetProperty("Status", "A");

            }

            if (entry.State == EntityState.Added)
            {
                _ = entry.SetProperty("CreatedAt", DateTime.UtcNow)
                .SetProperty("CreatedBy", request.Usuario?.IdUsuario ?? 0)
                .SetProperty("Active", true)
                .SetProperty("Status", "A");
            }
        }
    }
}