
using FundacionAMA.Domain.Shared.Entities.Dtos;

namespace FundacionAMA.Domain.DTO.Company.Filter
{
    public class CompanyFilter: RequestPaginated
    {
        public string Identificacion { get; set; }
    }
}
