using FundacionAMA.Domain.DTO.ActivityType.Dto;
using FundacionAMA.Domain.DTO.ActivityType.FilterDto;
using FundacionAMA.Domain.DTO.ActivityType.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;


namespace FundacionAMA.Application.Services.ActivityTypeApp
{
    public class ActivityTypeApp : IActivityTypeServiceApp
    {
        private readonly IActivityTypeService _activityTypeService;

        public ActivityTypeApp(IActivityTypeService activityTypeService)
        {
            _activityTypeService = activityTypeService;
        }

        public Task<IOperationResult> Create(IOperationRequest<ActivityTypeRequest> entity)
        {
            return _activityTypeService.Create(entity);
        }

        public Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            return _activityTypeService.Delete(id);
        }

        public Task<IOperationResultList<ActivityTypeDto>> GetAll(IOperationRequest<ActivityTypeFilter> filter)
        {
            return _activityTypeService.GetAll(filter);
        }

        public Task<IOperationResult<ActivityTypeDto>> GetById(int id)
        {
            return _activityTypeService.GetById(id);
        }

        public Task<IOperationResult> Update(int id, IOperationRequest<ActivityTypeRequest> entity)
        {
            return _activityTypeService.Update(id, entity);
        }
    }
}
