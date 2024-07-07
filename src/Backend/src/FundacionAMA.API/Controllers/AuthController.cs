using FundacionAMA.Application.DTO.AuthDTO;
using FundacionAMA.Application.Services.AuthApp;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundacionAMA.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase
{

    private readonly IAuthAppService _authService;

    public AuthController(IAuthAppService authService)
    {
        _authService = authService;
    }


    [HttpPost()]
    public IActionResult Login([FromBody] AuthRequest login)
    {

        var _auth = _authService.Login(login);
        if (_auth.Autenticate)
            return Ok(_auth);

        return Unauthorized(_auth);
    }

    [HttpPost("ResetPassword")]
    public IActionResult ResetPassword([FromBody] ResetPasswordRequest login)
    {

        var response = _authService.ResetPassword(login);

        if (response.success)
            return Ok(new { message = response.message });

        return BadRequest(new { message = response.message });



    }

    [HttpPost("SendCodeToResetPassword")]
    public async Task<IActionResult> SendCodeToResetPassword([FromBody] SendCodeToResetPasswordRequest login)
    {

        var response = await _authService.SendCodeToResetPassword(login);
        if (response.success)
            return Ok(new { message = response.message });

        return BadRequest(new { message = response.message });
    }

}
