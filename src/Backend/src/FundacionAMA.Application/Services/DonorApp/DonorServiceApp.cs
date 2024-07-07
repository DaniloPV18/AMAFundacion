using FundacionAMA.Domain.DTO.Donor.Dto;
using FundacionAMA.Domain.DTO.Donor.Filter;
using FundacionAMA.Domain.DTO.Donor.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Application.Services.DonorApp
{
    public class DonorServiceApp : IDonorServiceApp
    {
        private readonly IDonorService _donorService;

        public DonorServiceApp(IDonorService donorService)
        {
            _donorService = donorService;
        }

        public Task<IOperationResult> Create(IOperationRequest<DonorResquest> entity)
        {
            return _donorService.Create(entity);
        }

        public Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            return _donorService.Delete(id);
        }

        public Task<IOperationResultList<DonorDto>> GetAll(DonorFilter filter)
        {
            return _donorService.GetAll(filter);
        }

        public Task<IOperationResult<DonorDto>> GetById(int id)
        {
            return _donorService.GetById(id);
        }

        public Task<IOperationResult> Update(int id, IOperationRequest<DonorResquest> entity)
        {
            return _donorService.Update(id, entity);
        }
    }
}
