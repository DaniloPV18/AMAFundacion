using FundacionAMA.Domain.DTO.Company.Dto;
using FundacionAMA.Domain.DTO.Company.Filter;
using FundacionAMA.Domain.DTO.Company.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;


namespace FundacionAMA.Application.Services.CompanyApp
{
    public interface ICompanyAppService : ICrudService<IOperationRequest<CompanyRequest>, CompanyDto, IOperationRequest<CompanyFilter>, int>
    {

    }
}
