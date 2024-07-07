using FundacionAMA.Domain.DTO.Beneficiary.Dto;
using FundacionAMA.Domain.DTO.Beneficiary.FilterDto;
using FundacionAMA.Domain.DTO.Beneficiary.Request;

namespace FundacionAMA.Domain.Interfaces.Services
{
    /// <summary>
    /// servicio de beneficiario
    /// </summary>
    public interface IBeneficiaryervice : ICrudService<IOperationRequest<BeneficiaryRequest>, BeneficiaryDto, BeneficiaryFilter, int>
    {
    }
}
