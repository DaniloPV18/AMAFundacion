using FundacionAMA.Domain.Shared.Entities.Dtos;

namespace FundacionAMA.Domain.DTO.Beneficiary.FilterDto
{
    public class BeneficiaryFilter : RequestPaginated
    {
        public string? Identification { get; set; }
        public int? PersonId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
