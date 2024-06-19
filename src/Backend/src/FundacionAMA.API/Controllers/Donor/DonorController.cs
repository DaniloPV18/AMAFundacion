using FundacionAMA.Application.Services.DonorApp;
using FundacionAMA.Domain.DTO.Donor.Dto;
using FundacionAMA.Domain.DTO.Donor.Filter;
using FundacionAMA.Domain.DTO.Donor.Request;
using FundacionAMA.Domain.Interfaces.Controller.Donor;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using FundacionAMA.Domain.Shared.Interfaces.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FundacionAMA.API.Controllers.Donor
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DonorController : ControllerBase, IDonorController
    {
        private readonly IDonorServiceApp _service;

        public DonorController(IDonorServiceApp service)
        {
            _service = service;
        }
        /// <summary>
        /// obtener donante por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IOperationResult<DonorDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetById(int id)
        {
            IOperationResult<DonorDto> result = await _service.GetById(id);
            return StatusCode(result);
        }
        /// <summary>
        /// obtener todos los donantes paginado
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(typeof(IOperationResult<DonorDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetAll([FromQuery] DonorFilter filter)
        {
            IOperationResultList<DonorDto> result = await _service.GetAll(filter);
            return StatusCode(result);
        }
        /// <summary>
        /// creacion de donantes
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        [HttpPost]
        [ProducesResponseType(typeof(IOperationResult<DonorDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Create(DonorResquest entity)
        {
            IOperationResult result = await _service.Create(entity.ToRequest(this));
            return StatusCode(result);
        }
        /// <summary>
        /// actualizar donante
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IOperationResult<DonorDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Update(int id, DonorResquest entity)
        {
            IOperationResult result = await _service.Update(id, entity.ToRequest(this));
            return StatusCode(result);
        }
        /// <summary>
        /// eliminar donante
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IOperationResult<DonorDto>), 200)]
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
