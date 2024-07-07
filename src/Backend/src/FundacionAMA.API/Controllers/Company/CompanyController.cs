using FundacionAMA.Application.Services.BrigadeApp;
using FundacionAMA.Application.Services.CompanyApp;
using FundacionAMA.Domain.DTO.Brigade.Dto;
using FundacionAMA.Domain.DTO.Brigade.FilterDto;
using FundacionAMA.Domain.DTO.Brigade.Request;
using FundacionAMA.Domain.DTO.Company.Dto;
using FundacionAMA.Domain.DTO.Company.Filter;
using FundacionAMA.Domain.DTO.Company.Request;
using FundacionAMA.Domain.Interfaces.Controller.Company;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using FundacionAMA.Domain.Shared.Interfaces.Operations;
using Microsoft.AspNetCore.Mvc;

namespace FundacionAMA.API.Controllers.Company
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController: ControllerBase, ICompanyController
    {
        private readonly ICompanyAppService _companyAppService;

        public CompanyController(ICompanyAppService companyAppService)
        {
            _companyAppService = companyAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IOperationResult), 201)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Create(CompanyRequest entity)
        {
            var Result = await _companyAppService.Create(entity.ToRequest(this));
            return StatusCode(Result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IOperationResult), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Delete(int id)
        {
            var Result = await _companyAppService.Delete(id.ToRequest(this));
            return StatusCode(Result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IOperationResultList<CompanyDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetAll([FromQuery] CompanyFilter filter)
        {
            var Result = await _companyAppService.GetAll(filter.ToRequest(this));
            return StatusCode(Result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IOperationResult<CompanyDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetById(int id)
        {
            var Result = await _companyAppService.GetById(id);
            return StatusCode(Result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Update(int id, CompanyRequest entity)
        {
            var Result = await _companyAppService.Update(id, entity.ToRequest(this));
            return StatusCode(Result);
        }
    }
}
