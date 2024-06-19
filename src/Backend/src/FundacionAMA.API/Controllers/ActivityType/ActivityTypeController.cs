using FundacionAMA.Application.Services.ActivityTypeApp;
using FundacionAMA.Domain.DTO.ActivityType.Dto;
using FundacionAMA.Domain.DTO.ActivityType.FilterDto;
using FundacionAMA.Domain.DTO.ActivityType.Request;
using FundacionAMA.Domain.DTO.Donation.Filter;
using FundacionAMA.Domain.DTO.Donation.Request;
using FundacionAMA.Domain.Interfaces.Controller.ActivityType;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using FundacionAMA.Domain.Shared.Interfaces.Operations;
using Microsoft.AspNetCore.Mvc;

namespace FundacionAMA.API.Controllers.ActivityType
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityTypeController: ControllerBase, IActivityTypeController
    {
        private readonly IActivityTypeServiceApp _activityTypeServiceApp;

        public ActivityTypeController(IActivityTypeServiceApp activityTypeServiceApp)
        {
            _activityTypeServiceApp = activityTypeServiceApp;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IOperationResult<ActivityTypeDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetById(int id)
        {
            IOperationResult<ActivityTypeDto> result = (IOperationResult<ActivityTypeDto>)await _activityTypeServiceApp.GetById(id);
            return StatusCode(result);
        }


        [HttpGet]
        [ProducesResponseType(typeof(IOperationResult<ActivityTypeDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetAll([FromQuery] ActivityTypeFilter filter)
        {
            IOperationResultList<ActivityTypeDto> result = await _activityTypeServiceApp.GetAll(filter.ToRequest(this));
            return StatusCode(result);
        }


        [HttpPost]
        [ProducesResponseType(typeof(IOperationResult<ActivityTypeDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Create(ActivityTypeRequest entity)
        {
            IOperationResult result = await _activityTypeServiceApp.Create(entity.ToRequest(this));
            return StatusCode(result);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IOperationResult<ActivityTypeDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Update(int id, ActivityTypeRequest entity)
        {
            IOperationResult result = await _activityTypeServiceApp.Update(id, entity.ToRequest(this));
            return StatusCode(result);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IOperationResult<ActivityTypeDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Delete(int id)
        {
            IOperationResult result = await _activityTypeServiceApp.Delete(id.ToRequest(this));
            return StatusCode(result);
        }


    }
}
