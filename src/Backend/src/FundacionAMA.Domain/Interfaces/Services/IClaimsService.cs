using System.Security.Claims;

namespace FundacionAMA.Domain.Interfaces.Services;

public interface IClaimsService
{

    public bool Autenticated { get; }
    public int UserId { get; }
    public ClaimsPrincipal? UserAutenticated { get; }

}
