using FundacionAMA.Domain.DTO.Person.Request;

namespace FundacionAMA.Domain.DTO.Beneficiary.Request
{
    public class BeneficiaryRequest
    {
        public string Description { get; set; }
        public required PersonRequestHeader Person { get; set; }
    }
}
