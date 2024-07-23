using System.Linq.Expressions;

namespace FundacionAMA.Domain.Interfaces.Services;

public interface ISmtpConfigurationService
{
    SmtpConfiguration? GetById(int id);
    IEnumerable<SmtpConfiguration> GetAll(Expression<Func<SmtpConfiguration, bool>>? filter = null);
    void Create(SmtpConfiguration obj);
    void Update(SmtpConfiguration obj);
    SmtpConfiguration GetByProfileId(int id);
    void UpdatePassword(SmtpConfiguration obj);
}
