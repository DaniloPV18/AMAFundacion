using FundacionAMA.Application.Services.VolunteeerApp;
using FundacionAMA.Domain.DTO.Volunteer.Dto;
using FundacionAMA.Domain.DTO.Volunteer.Filter;
using FundacionAMA.Domain.DTO.Volunteer.Request;
using FundacionAMA.Domain.Interfaces.Controller.Volunteer;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using FundacionAMA.Domain.Shared.Interfaces.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundacionAMA.API.Controllers.Volunteer
{
    /// <summary>
    /// controlador de donacion
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VolunteerController : ControllerBase, IVolunteerController
    {
        private readonly IVolunteerServiceApp _service;
        /// <summary>
        /// contructior de donacion
        /// </summary>
        /// <param name="service"></param>
        public VolunteerController(IVolunteerServiceApp service)
        {
            _service = service;
        }
        /// <summary>
        /// obtener donacion por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IOperationResult<VolunteerDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetById(int id)
        {
            IOperationResult<VolunteerDto> result = await _service.GetById(id);
            return StatusCode(result);
        }
        /// <summary>
        /// Obtener todas las donaciones paginado
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IOperationResult<VolunteerDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetAll([FromQuery] VolunteerFilter filter)
        {
            IOperationResultList<VolunteerDto> result = await _service.GetAll(filter);
            return StatusCode(result);
        }
        /// <summary>
        /// Creacion de donaciones
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(IOperationResult<VolunteerDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Create(VolunteerRequest entity)
        {
            IOperationResult result = await _service.Create(entity.ToRequest(this));
            return StatusCode(result);
        }
        /// <summary>
        /// actualizar donacion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IOperationResult<VolunteerDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Update(int id, VolunteerRequest entity)
        {
            IOperationResult result = await _service.Update(id, entity.ToRequest(this));
            return StatusCode(result);
        }
        /// <summary>
        /// eliminar donacion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IOperationResult<VolunteerDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Delete(int id)
        {
            IOperationResult result = await _service.Delete(id.ToRequest(this));
            return StatusCode(result);
        }
    }

}
