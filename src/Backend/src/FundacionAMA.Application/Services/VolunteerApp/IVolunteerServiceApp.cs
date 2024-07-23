


using FundacionAMA.Domain.DTO.Volunteer.Dto;
using FundacionAMA.Domain.DTO.Volunteer.Filter;
using FundacionAMA.Domain.DTO.Volunteer.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;


namespace FundacionAMA.Application.Services.VolunteeerApp
{
    public interface IVolunteerServiceApp : ICrudService<IOperationRequest<VolunteerRequest>, VolunteerDto, VolunteerFilter, int>
    {
    }
}
