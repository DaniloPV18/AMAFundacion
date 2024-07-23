using FundacionAMA.Domain.Interfaces.Repositories;

namespace FundacionAMA.Infrastructure.Persistence.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AMADbContext _dbContext;

    public UnitOfWork(AMADbContext dbContext)
        =>
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));


    public async Task SaveChangesAsync()
        =>
        await _dbContext.SaveChangesAsync();
    public void SaveChanges()
        =>
        _dbContext.SaveChanges();

    public void Dispose()
        =>
        _dbContext.Dispose();


}
