using FundacionAMA.Domain.DTO.EmailServiceProfile;

namespace FundacionAMA.Domain.Interfaces.Services;

public interface ISMTPService
{
    Task<(bool IsSuccessful, string Message)> SendEmailAsync(EmailRequest email, SmtpConfiguration configuration);
}
