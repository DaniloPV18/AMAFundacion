using FundacionAMA.Domain.DTO.Catalogo.Dto;
using FundacionAMA.Domain.DTO.Catalogo.Filter;
using FundacionAMA.Domain.DTO.Catalogo.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Application.Services.CatalogoApp
{
    internal class DonationTypeServiceApp : IDonationTypeServiceApp
    {
        private readonly IDonationTypeService _donationTypeService;

        public DonationTypeServiceApp(IDonationTypeService donationTypeService)
        {
            _donationTypeService = donationTypeService;
        }

        public Task<IOperationResult> Create(IOperationRequest<DonationTypeRequest> entity)
        {
            return _donationTypeService.Create(entity);
        }

        public Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            return _donationTypeService.Delete(id);
        }

        public Task<IOperationResultList<DonationTypeDto>> GetAll(DonationTypeFilter filter)
        {
            return _donationTypeService.GetAll(filter);
        }

        public Task<IOperationResult<DonationTypeDto>> GetById(int id)
        {
            return _donationTypeService.GetById(id);
        }

        public Task<IOperationResult> Update(int id, IOperationRequest<DonationTypeRequest> entity)
        {
            return _donationTypeService.Update(id, entity);
        }
    }
}
