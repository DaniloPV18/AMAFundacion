using FundacionAMA.Application.Services.BeneficaryApp;
using FundacionAMA.Domain.DTO.Beneficiary.FilterDto;
using FundacionAMA.Domain.DTO.Beneficiary.Request;
using FundacionAMA.Domain.Interfaces.Controller.Beneficiary;
using FundacionAMA.Domain.Shared.Extensions.Bussines;

using Microsoft.AspNetCore.Authorization;


// using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundacionAMA.API.Controllers.Beneficiary
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BeneficiaryController : ControllerBase, IBeneficiaryController
    {
        private readonly IBeneficiaryAppService _service;

        public BeneficiaryController(IBeneficiaryAppService beneficiaryAppService)
        {
            _service = beneficiaryAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(BeneficiaryRequest entity)
        {
            

            Domain.Shared.Interfaces.Operations.IOperationResult result = await _service.Create(entity.ToRequest(this));
            return StatusCode(result);
        }
        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
            Domain.Shared.Interfaces.Operations.IOperationResult result = await _service.Delete(id.ToRequest(this));
            return StatusCode(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] BeneficiaryFilter filter)
        {
            Domain.Shared.Interfaces.Operations.IOperationResultList<Domain.DTO.Beneficiary.Dto.BeneficiaryDto> result = await _service.GetAll(filter);
            return StatusCode(result);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            Domain.Shared.Interfaces.Operations.IOperationResult<Domain.DTO.Beneficiary.Dto.BeneficiaryDto> result = await _service.GetById(id);
            return StatusCode(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BeneficiaryRequest entity)
        {
            Domain.Shared.Interfaces.Operations.IOperationResult result = await _service.Update(id, entity.ToRequest(this));
            return StatusCode(result);
        }
    }
}
