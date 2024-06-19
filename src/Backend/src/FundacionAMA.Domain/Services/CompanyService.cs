using FundacionAMA.Domain.DTO.Company.Dto;
using FundacionAMA.Domain.DTO.Company.Filter;
using FundacionAMA.Domain.DTO.Company.Request;
using FundacionAMA.Domain.DTO.Company.Dto;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundacionAMA.Domain.DTO.Company.Dto;

namespace FundacionAMA.Domain.Services
{
    public class CompanyService : ICompanyService
    {
        public readonly ICompanyRepository _repository;

        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<CompanyRequest> entity)
        {
            try
            {

                var request = entity.Data.MapTo<Company>();
                _repository.InsertAsync(request);
                _repository.SaveChangesAsync(entity);

                return await new Task<IOperationResult>(() => new OperationResult(System.Net.HttpStatusCode.Created, "la brigada fue creada con exito"));
            }
            catch (Exception ex)
            {

                return await ex.ToResultAsync();
            }
        }

        public async Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            try
            {

                var brigada = await _repository.GetByIdAsync(id);
                if (brigada == null)
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "No se encontro la brigada");
                await _repository.DeleteAsync(brigada);

                return new OperationResult(System.Net.HttpStatusCode.NoContent, "La brigada fue eliminada con exito");

            }
            catch (Exception ex)
            {

                return await ex.ToResultAsync();
            }
        }

        public async Task<IOperationResultList<CompanyDto>> GetAll(IOperationRequest<CompanyFilter> filter)
        {
            try
            {

                var Donante = await _repository.ToResultListPaginatedAscyn<CompanyDto>(filter.Data.Offset, filter.Data.Take);

                return Donante;
            }
            catch (Exception ex)
            {

                return await ex.ToResultListAsync<CompanyDto>();
            }
        }

        public async Task<IOperationResult<CompanyDto>> GetById(int id)
        {
            try
            {

                var brigada = await _repository.GetByIdAsync(id);
                if (brigada == null)
                    return new OperationResult<CompanyDto>(System.Net.HttpStatusCode.NotFound, "No se encontro la brigada");

                return await brigada.ToResultAsync<Company, CompanyDto>();

            }
            catch (Exception ex)
            {

                return await ex.ToResultAsync<CompanyDto>();
            }
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<CompanyRequest> entity)
        {
            try
            {

                var brigara = await _repository.GetByIdAsync(id);
                if (brigara == null)
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "No se encontro el donante");

                var request = entity.Data.MapTo<Company>(brigara);
                await _repository.UpdateAsync(request);

                return new OperationResult(System.Net.HttpStatusCode.NoContent, "El donante fue actualizado con exito");
            }
            catch (Exception ex)
            {

                return await ex.ToResultAsync();
            }
        }
    }
}
