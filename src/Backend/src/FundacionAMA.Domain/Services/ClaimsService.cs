using Microsoft.AspNetCore.Http;

using System.Security.Claims;

namespace FundacionAMA.Domain.Services;

public class ClaimsService : IClaimsService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ClaimsService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public bool Autenticated => _autenticated();
    public int UserId => _userId();

    public ClaimsPrincipal? UserAutenticated => _userAutenticated();
    private ClaimsPrincipal? _userAutenticated()
        =>
        _httpContextAccessor.HttpContext.User;

    private bool _autenticated()
        =>
        _httpContextAccessor.HttpContext.User.Identity?.IsAuthenticated ?? default;
    private int _userId()
        =>
        int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == "Id")?.Value ?? "0");

}
