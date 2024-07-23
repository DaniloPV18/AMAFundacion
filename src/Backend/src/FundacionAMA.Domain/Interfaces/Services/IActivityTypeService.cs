using FundacionAMA.Domain.DTO.ActivityType.Dto;
using FundacionAMA.Domain.DTO.ActivityType.FilterDto;
using FundacionAMA.Domain.DTO.ActivityType.Request;


namespace FundacionAMA.Domain.Interfaces.Services
{
    public interface IActivityTypeService : ICrudService<IOperationRequest<ActivityTypeRequest>, ActivityTypeDto, IOperationRequest<ActivityTypeFilter>, int>
    {

    }
}
