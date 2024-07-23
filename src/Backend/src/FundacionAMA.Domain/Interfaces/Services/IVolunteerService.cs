using FundacionAMA.Domain.DTO.Volunteer.Dto;
using FundacionAMA.Domain.DTO.Volunteer.Filter;
using FundacionAMA.Domain.DTO.Volunteer.Request;

namespace FundacionAMA.Domain.Interfaces.Services
{
    public interface IVolunteerService : ICrudService<IOperationRequest<VolunteerRequest>, VolunteerDto, VolunteerFilter, int>
    {
    }
}