using FundacionAMA.Application.DTO.SmtpConfigurationDTO;

namespace FundacionAMA.Application.Services.SmtpConfigurationApp;

public interface ISmtpConfigurationAppService
{
    SmtpConfigurationDTO GetById(int id);
    IEnumerable<SmtpConfigurationDTO> GetAll(SmtpConfigurationQuery filter);
    SmtpConfigurationDTO Create(SmtpConfigurationRequest obj);
    void Update(int id, SmtpConfigurationUpdate obj);
    void UpdatePassword(int id, string password);

}
