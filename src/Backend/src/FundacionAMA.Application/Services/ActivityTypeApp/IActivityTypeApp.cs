using FundacionAMA.Domain.DTO.ActivityType.Dto;
using FundacionAMA.Domain.DTO.ActivityType.FilterDto;
using FundacionAMA.Domain.DTO.ActivityType.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Application.Services.ActivityTypeApp
{
    public interface IActivityTypeServiceApp : ICrudService<IOperationRequest<ActivityTypeRequest>, ActivityTypeDto, IOperationRequest<ActivityTypeFilter>, int>
    {
    }
}
