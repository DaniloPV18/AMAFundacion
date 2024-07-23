namespace FundacionAMA.Domain.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{

    Task SaveChangesAsync();
    void SaveChanges();

}
