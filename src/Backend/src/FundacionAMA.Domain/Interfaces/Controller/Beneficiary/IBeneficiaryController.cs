using FundacionAMA.Domain.DTO.Beneficiary.FilterDto;
using FundacionAMA.Domain.DTO.Beneficiary.Request;

namespace FundacionAMA.Domain.Interfaces.Controller.Beneficiary
{
    public interface IBeneficiaryController : ICrudController<BeneficiaryRequest, BeneficiaryFilter, int>
    {
    }
}
