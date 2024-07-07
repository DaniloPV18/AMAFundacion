using FundacionAMA.Domain.DTO.Volunteer.Filter;
using FundacionAMA.Domain.DTO.Volunteer.Request;

namespace FundacionAMA.Domain.Interfaces.Controller.Volunteer
{

    public interface IVolunteerController : ICrudController<VolunteerRequest, VolunteerFilter, int>
    {
    }
}
