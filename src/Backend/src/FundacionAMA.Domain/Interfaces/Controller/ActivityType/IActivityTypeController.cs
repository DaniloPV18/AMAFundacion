using FundacionAMA.Domain.DTO.ActivityType.FilterDto;
using FundacionAMA.Domain.DTO.ActivityType.Request;

namespace FundacionAMA.Domain.Interfaces.Controller.ActivityType
{

    public interface IActivityTypeController : ICrudController<ActivityTypeRequest, ActivityTypeFilter, int>
    {
    }
}
