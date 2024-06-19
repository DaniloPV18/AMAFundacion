using FundacionAMA.Domain.DTO.Beneficiary.Dto;
using FundacionAMA.Domain.DTO.Beneficiary.FilterDto;
using FundacionAMA.Domain.DTO.Beneficiary.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Application.Services.BeneficaryApp
{
    /// <summary>
    /// servicio de beneficiario
    /// </summary>
    public interface IBeneficiaryAppService : ICrudService<IOperationRequest<BeneficiaryRequest>, BeneficiaryDto, BeneficiaryFilter, int>
    {
    }
}
