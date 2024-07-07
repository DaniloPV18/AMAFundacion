
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
    /// <summary>
    /// representacion de donacion
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DonationTypeController : ControllerBase, IDonationTypeController
    {
        private readonly IDonationTypeServiceApp _donationTypeServiceApp;

        public DonationTypeController(IDonationTypeServiceApp donationTypeServiceApp)
        {
            _donationTypeServiceApp = donationTypeServiceApp;
        }
        /// <summary>
        /// creacion de tipo de donacion
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        [HttpPost]
        [ProducesResponseType(typeof(IOperationResult<DonationTypeDto>), 201)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Create(DonationTypeRequest entity)
        {
            Domain.Shared.Interfaces.Operations.IOperationResult result = await _donationTypeServiceApp.Create(entity.ToRequest(this));
            return StatusCode(result);
        }
        /// <summary>
        /// eliminar tipo de donacion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Delete(int id)
        {
            Domain.Shared.Interfaces.Operations.IOperationResult result = await _donationTypeServiceApp.Delete(id.ToRequest(this));

            return StatusCode(result);
        }
        /// <summary>
        /// obtener todos los tipos de donacion paginado
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IOperationResultList<DonationTypeDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetAll([FromQuery] DonationTypeFilter filter)
        {
            Domain.Shared.Interfaces.Operations.IOperationResultList<Domain.DTO.Catalogo.Dto.DonationTypeDto> result = await _donationTypeServiceApp.GetAll(filter);
            return StatusCode(result);

        }
        /// <summary>
        ///  obtener tipo de donacion por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IOperationResult<DonationTypeDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]

        public async Task<IActionResult> GetById(int id)
        {
            Domain.Shared.Interfaces.Operations.IOperationResult<Domain.DTO.Catalogo.Dto.DonationTypeDto> result = await _donationTypeServiceApp.GetById(id);
            return StatusCode(result);
        }
        /// <summary>
        /// actualizar tipo de donacion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Update(int id, DonationTypeRequest entity)
        {
            Domain.Shared.Interfaces.Operations.IOperationResult result = await _donationTypeServiceApp.Update(id, entity.ToRequest(this));
            return StatusCode(result);
        }
    }
}
