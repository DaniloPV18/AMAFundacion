using FundacionAMA.Application.DTO.SmtpConfigurationDTO;
using FundacionAMA.Application.Services.SmtpConfigurationApp;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundacionAMA.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SmtpConfigurationController : ControllerBase
{
    private readonly ISmtpConfigurationAppService _smtpService;

    public SmtpConfigurationController(ISmtpConfigurationAppService smtpService)
    {
        _smtpService = smtpService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SmtpConfigurationDTO>>> GetAll([FromQuery] SmtpConfigurationQuery filter)
    {
        var _obj = _smtpService.GetAll(filter);
        return Ok(_obj);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var _obj = _smtpService.GetById(id);

        if (_obj == null)
            return NotFound();

        return Ok(_obj);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] SmtpConfigurationRequest request)
    {
        var _obj = _smtpService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = _obj.Id }, _obj);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SmtpConfigurationUpdate user)
    {
        _smtpService.Update(id, user);
        return NoContent();
    }


    [HttpPut("password/{id}")]
    public IActionResult Put(int id, [FromBody] string password)
    {
        _smtpService.UpdatePassword(id, password);
        return NoContent();
    }

}
