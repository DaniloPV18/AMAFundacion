using FundacionAMA.Application.Services.PersonApp;
using FundacionAMA.Domain.DTO.Person;
using FundacionAMA.Domain.DTO.Person.FilterDto;
using FundacionAMA.Domain.DTO.Person.Request;
using FundacionAMA.Domain.Interfaces.Controller.Person;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using FundacionAMA.Domain.Shared.Interfaces.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundacionAMA.API.Controllers.Person
{
    /// <summary>
    /// Reursos para la gestion de personas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonController : ControllerBase, IPersonController
    {
        private readonly IPersonAppService _personAppService;
        public PersonController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }
        /// <summary>
        /// obtener persona por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IOperationResult<PersonDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetById(int id)
        {
            IOperationResult<PersonDto> result = await _personAppService.GetById(id);
            return StatusCode(result);
        }
        /// <summary>
        /// Obtener todas las personas paginado
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IOperationResultList<PersonDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetAll([FromQuery] PersonFilter filter)
        {
            IOperationResultList<PersonDto> result = await _personAppService.GetAll(filter);
            return StatusCode(result);
        }
        /// <summary>
        /// creacion de personas
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(IOperationResult), 201)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Create(PersonRequest entity)
        {
            IOperationResult result = await _personAppService.Create(entity.ToRequest(this));
            return StatusCode(result);
        }
        /// <summary>
        ///  actualizar persona
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IOperationResultList<PersonDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Update(int id, PersonRequest entity)
        {
            IOperationResult result = await _personAppService.Update(id, entity.ToRequest(this));
            return StatusCode(result);
        }
        /// <summary>
        /// eliminar persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IOperationResultList<PersonDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Delete(int id)
        {
            IOperationResult result = await _personAppService.Delete(id.ToRequest(this));
            return StatusCode(result);
        }
    }
}
