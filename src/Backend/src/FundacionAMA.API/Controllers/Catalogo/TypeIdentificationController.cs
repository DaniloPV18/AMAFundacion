using FundacionAMA.Application.Services.CatalogoApp;
using FundacionAMA.Domain.DTO.Catalogo.Dto;
using FundacionAMA.Domain.DTO.Catalogo.Filter;
using FundacionAMA.Domain.DTO.Catalogo.Request;
using FundacionAMA.Domain.Interfaces.Controller.Catalogo;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using Microsoft.AspNetCore.Authorization;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

using Microsoft.AspNetCore.Mvc;

namespace FundacionAMA.API.Controllers.Catalogo
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TypeIdentificationController : ControllerBase, ITypeIdentificationController
    {
        private readonly ITypeIdentificationServiceApp _service;

        public TypeIdentificationController(ITypeIdentificationServiceApp service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IOperationResult), 201)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Create(TypeIdentificationRequest entity)
        {
            Domain.Shared.Interfaces.Operations.IOperationResult result = await _service.Create(entity.ToRequest(this));
            return StatusCode(result);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Delete(short id)
        {
            Domain.Shared.Interfaces.Operations.IOperationResult result = await _service.Delete(id.ToRequest(this));
            return StatusCode(result);
        }
        [HttpGet]
        [ProducesResponseType(typeof(IOperationResultList<TypeIdentificationDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetAll([FromQuery] TypeIdentificationFilter filter)
        {
            Domain.Shared.Interfaces.Operations.IOperationResultList<Domain.DTO.Catalogo.Dto.TypeIdentificationDto> result = await _service.GetAll(filter);
            return StatusCode(result);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IOperationResult<TypeIdentificationDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetById(short id)
        {
            Domain.Shared.Interfaces.Operations.IOperationResult<Domain.DTO.Catalogo.Dto.TypeIdentificationDto> result = await _service.GetById(id);
            return StatusCode(result);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Update(short id, TypeIdentificationRequest entity)
        {
            Domain.Shared.Interfaces.Operations.IOperationResult result = await _service.Update(id, entity.ToRequest(this));
            return StatusCode(result);
        }
    }
}
