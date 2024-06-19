using FundacionAMA.Domain.DTO.Beneficiary.Dto;
using FundacionAMA.Domain.DTO.Beneficiary.FilterDto;
using FundacionAMA.Domain.DTO.Beneficiary.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Application.Services.BeneficaryApp
{
    internal class BeneficiaryAppService : IBeneficiaryAppService
    {
        private readonly IBeneficiaryervice _beneficiaryervice;

        public BeneficiaryAppService(IBeneficiaryervice beneficiaryervice)
        {
            _beneficiaryervice = beneficiaryervice;
        }

        public async Task<IOperationResult> Create(IOperationRequest<BeneficiaryRequest> entity)
        {
            return await _beneficiaryervice.Create(entity);
        }

        public async Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            return await _beneficiaryervice.Delete(id);
        }

        public async Task<IOperationResultList<BeneficiaryDto>> GetAll(BeneficiaryFilter filter)
        {
            return await _beneficiaryervice.GetAll(filter);
        }

        public async Task<IOperationResult<BeneficiaryDto>> GetById(int id)
        {
            return await _beneficiaryervice.GetById(id);
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<BeneficiaryRequest> entity)
        {
            return await _beneficiaryervice.Update(id, entity);
        }
    }
}
