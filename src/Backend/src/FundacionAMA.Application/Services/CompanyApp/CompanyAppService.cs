using FundacionAMA.Domain.DTO.Company.Dto;
using FundacionAMA.Domain.DTO.Company.Filter;
using FundacionAMA.Domain.DTO.Company.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundacionAMA.Application.Services.CompanyApp
{
    public class CompanyAppService : ICompanyAppService
    {
        private readonly ICompanyService _companyService;

        public CompanyAppService(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<IOperationResult> Create(IOperationRequest<CompanyRequest> entity)
        {
            return await _companyService.Create(entity);
        }

        public async Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            return await _companyService.Delete(id);
        }

        public async Task<IOperationResultList<CompanyDto>> GetAll(IOperationRequest<CompanyFilter> filter)
        {
            return await _companyService.GetAll(filter);
        }

        public async Task<IOperationResult<CompanyDto>> GetById(int id) => await _companyService.GetById(id);

        // aqui modifico 
        public async Task<IOperationResult<CompanyDto>> GetByIdentification(string identification) => await _companyService.GetByIdentification(identification);

        public Task<IOperationResult<int>> GetCount()
        {
            return _companyService.GetCount();
        }

        //

        public async Task<IOperationResult> Update(int id, IOperationRequest<CompanyRequest> entity) => await _companyService.Update(id, entity);

    }
}
