using FundacionAMA.Application.DTO.UserDTO;
using FundacionAMA.Application.Services.UserApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundacionAMA.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{

    private readonly IUserAppService _userService;

    public UserController(IUserAppService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll([FromQuery] UserQuery filter)
    {
        var usuarios = _userService.GetAll(filter);
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var usuario = _userService.GetById(id);

        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserRequest request)
    {
        var user = _userService.Create(request);
        //return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        return Ok(_userService.GetAll(new UserQuery()));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UserUpdate user)
    {
        _userService.Update(id, user);
        //return NoContent();
        return Ok(_userService.GetAll(new UserQuery()));
    }
}
