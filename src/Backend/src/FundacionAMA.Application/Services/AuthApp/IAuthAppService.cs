using FundacionAMA.Application.DTO.AuthDTO;

namespace FundacionAMA.Application.Services.AuthApp;

public interface IAuthAppService
{
    AuthDTO Login(AuthRequest login);
    Task<ResetPasswordDTO> SendCodeToResetPassword(SendCodeToResetPasswordRequest login);
    ResetPasswordDTO ResetPassword(ResetPasswordRequest login);
}
