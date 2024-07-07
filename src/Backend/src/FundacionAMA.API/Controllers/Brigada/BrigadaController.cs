using FundacionAMA.Application.Services.BrigadeApp;
using FundacionAMA.Domain.DTO.Brigade.Dto;
using FundacionAMA.Domain.DTO.Brigade.FilterDto;
using FundacionAMA.Domain.DTO.Brigade.Request;
using FundacionAMA.Domain.Interfaces.Controller.Brigade;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundacionAMA.API.Controllers.Brigada
{
    /// <summary>
    /// recibe los datos de la brigada
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrigadaController : ControllerBase, IBrigadeController
    {
        private readonly IBrigadeAppService _brigadeAppService;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="brigadeAppService"></param>
        public BrigadaController(IBrigadeAppService brigadeAppService)
        {
            _brigadeAppService = brigadeAppService;
        }

        /// <summary>
        /// creacion de brigada
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(IOperationResult), 201)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Create(BrigadeRequest entity)
        {
            IOperationResult Result = await _brigadeAppService.Create(entity.ToRequest(this));
            return StatusCode(Result);
        }
        /// <summary>
        /// eliminar brigada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]

        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Delete(int id)
        {
            IOperationResult Result = await _brigadeAppService.Delete(id.ToRequest(this));
            return StatusCode(Result);
        }
        /// <summary>
        /// obtener todas las brigadas paginado
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IOperationResultList<BrigadeDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetAll([FromQuery] BrigadeFilter filter)
        {
            IOperationResultList<BrigadeDto> Result = await _brigadeAppService.GetAll(filter);
            return StatusCode(Result);
        }
        /// <summary>
        /// obtener brigada por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IOperationResult<BrigadeDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetById(int id)
        {
            IOperationResult<BrigadeDto> Result = await _brigadeAppService.GetById(id);
            return StatusCode(Result);
        }
        /// <summary>
        /// Modificar brigada por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Update(int id, BrigadeRequest entity)
        {
            IOperationResult Result = await _brigadeAppService.Update(id, entity.ToRequest(this));
            return StatusCode(Result);
        }
    }
}
