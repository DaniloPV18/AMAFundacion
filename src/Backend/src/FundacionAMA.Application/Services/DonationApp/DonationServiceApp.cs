using FundacionAMA.Domain.DTO.Donation.Dto;
using FundacionAMA.Domain.DTO.Donation.Filter;
using FundacionAMA.Domain.DTO.Donation.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Application.Services.DonationApp
{
    internal class DonationServiceApp : IDonationServiceApp
    {
        private readonly IDonationService _donationService;

        public DonationServiceApp(IDonationService donationService)
        {
            _donationService = donationService;
        }

        public Task<IOperationResult> Create(IOperationRequest<DonationRequest> entity)
        {
            return _donationService.Create(entity);
        }

        public Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            return _donationService.Delete(id);
        }

        public Task<IOperationResultList<DonationDto>> GetAll(DonationFilter filter)
        {
            return _donationService.GetAll(filter);
        }

        public Task<IOperationResult<DonationDto>> GetById(int id)
        {
            return _donationService.GetById(id);
        }

        public Task<IOperationResult> Update(int id, IOperationRequest<DonationRequest> entity)
        {
            return _donationService.Update(id, entity);
        }
    }
}
