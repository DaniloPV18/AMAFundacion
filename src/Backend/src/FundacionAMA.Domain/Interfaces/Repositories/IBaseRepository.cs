using Microsoft.EntityFrameworkCore.Query;

using System.Linq.Expressions;

namespace FundacionAMA.Domain.Interfaces.Repositories;

public interface IBaseRepository<T> : IDisposable where T : class
{
    IQueryable<T> All { get; }
    T First(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    T? GetById(params object[] keyValues);
    T? FirstOrDefault(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    IEnumerable<T> GetAll(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    void Insert(T entity);
    void Update(T entity);
    void Detach(T entity);
    public bool Exists(Expression<Func<T, bool>> expression);
    public Task<bool> ExistsAscyn(Expression<Func<T, bool>> expression);
    Task<T> FirstAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    Task<T?> GetByIdAsync(params object[] keyValues);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    Task InsertAsync(T entity);

    Task DeleteAsync(T brigada);
    void SaveChanges(IOperationRequest? request = null);
    Task SaveChangesAsync(IOperationRequest? request = null);
    Task UpdateAsync(T entity);
    Task DetachAsync(T entity);
    IQueryable<T> GetAllQuerable(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    IOperationResultList<T> ToResultListPaginated(int Offset = 1, int? Take = 10);
    IOperationResultList<TResult> ToResultListPaginated<TResult>(int Offset = 1, int Take = 10) where TResult : class;
    Task<IOperationResultList<TResult>> ToResultListPaginatedAscyn<TResult>(int Offset = 1, int Take = 10) where TResult : class;
    IQueryable<T> OrderByDesc(params Expression<Func<T, object>>[] properties);
    IQueryable<T> OrderBy(params Expression<Func<T, object>>[] properties);
}


