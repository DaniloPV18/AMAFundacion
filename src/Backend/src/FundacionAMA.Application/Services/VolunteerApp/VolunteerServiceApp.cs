using FundacionAMA.Application.Services.VolunteeerApp;
using FundacionAMA.Domain.DTO.Donor.Request;
using FundacionAMA.Domain.DTO.Volunteer.Dto;
using FundacionAMA.Domain.DTO.Volunteer.Filter;
using FundacionAMA.Domain.DTO.Volunteer.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Entities.Operation;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Application.Services.VolunteerApp
{
    internal class VolunteerServiceApp : IVolunteerServiceApp
    {
        private readonly IVolunteerService _volunteerService;

        public VolunteerServiceApp(IVolunteerService volunteerService)
        {
            _volunteerService = volunteerService;
        }

        public async Task<IOperationResult> Create(IOperationRequest<VolunteerRequest> entity)
        {
            return await _volunteerService.Create(entity);
        }

        public Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            return _volunteerService.Delete(id);
        }

        public Task<IOperationResultList<VolunteerDto>> GetAll(VolunteerFilter filter)
        {
            return _volunteerService.GetAll(filter);
        }

        public Task<IOperationResult<VolunteerDto>> GetById(int id)
        {
            return _volunteerService.GetById(id);
        }

        public Task<IOperationResult> Update(int id, IOperationRequest<VolunteerRequest> entity)
        {
            return _volunteerService.Update(id, entity);
        }
    }
}

