namespace FundacionAMA.Domain.Interfaces.Services;

public interface IAuthService
{
    bool Autenticate(int userId, string password);
    (string Hash, string Salt) CreateHash(string password);

}
