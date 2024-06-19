using FundacionAMA.Domain.DTO.Beneficiary.Dto;
using FundacionAMA.Domain.DTO.Beneficiary.FilterDto;
using FundacionAMA.Domain.DTO.Beneficiary.Request;

using System.Linq.Expressions;

namespace FundacionAMA.Domain.Services
{
    internal class Beneficiaryervice : IBeneficiaryervice
    {
        private readonly IBeneficiaryRepository _beneficiaryRepository;
        private readonly IPersonRepository _personRepository;
        public Beneficiaryervice(IBeneficiaryRepository beneficiaryRepository, IPersonRepository personRepository)
        {
            _beneficiaryRepository = beneficiaryRepository;
            _personRepository = personRepository;
        }
        private async Task<bool> IsExitByIdentification(BeneficiaryRequest entity)
        {
            return await _personRepository.ExistsAscyn(e => e.Active && e.Identification == entity.Person.Identification);
        }
        private async Task<bool> IsExitByIdentificationUpdate(BeneficiaryRequest entity, int id)
        {
            return await _personRepository.ExistsAscyn(e => e.Active && e.Identification == entity.Person.Identification && e.Id != id);
        }

        public async Task<IOperationResult> Create(IOperationRequest<BeneficiaryRequest> entity)
        {
            try
            {

                entity.Data.Person.GetNameCompleted();
                Beneficiary request = entity.Data.MapTo<Beneficiary>();
                if (await IsExitByIdentification(entity.Data))
                {
                    return new OperationResult(System.Net.HttpStatusCode.Conflict, "Ya existe un beneficiario con la misma identificacion");
                }

                request.Person.Beneficiary = request;

                await _personRepository.InsertAsync(request.Person);
                await _personRepository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.Created, "El beneficiario fue creado con exito");

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
                Beneficiary? beneficiary = await _beneficiaryRepository.All
                    .Include(e => e.Person)
                    .FirstOrDefaultAsync(e => e.Active && e.Person.Id == id.Data && e.Person.Active == e.Active);

                if (beneficiary == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "No se encontro el beneficiario");
                }
                await _beneficiaryRepository.DeleteAsync(beneficiary);
                await _personRepository.DeleteAsync(beneficiary.Person);
                await _beneficiaryRepository.SaveChangesAsync(id);
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "El beneficiario fue eliminado con exito");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }

        }
        private static Expression<Func<Beneficiary, bool>> GetFilters(BeneficiaryFilter filter)
        {
            return e => e.Active &&
            (

            (filter.PersonId == null || e.PersonId == filter.PersonId) &&
            (string.IsNullOrEmpty(filter.Identification) || e.Person.Identification == filter.Identification) &&

            (string.IsNullOrEmpty(filter.Name) || e.Person.FirstName == filter.Name || e.Person.SecondName == filter.Name ||
            e.Person.LastName == filter.Name || e.Person.SecondLastName == filter.Name) &&
            (string.IsNullOrEmpty(filter.Email) || e.Person.Email == filter.Email)
                            );
        }

        public async Task<IOperationResultList<BeneficiaryDto>> GetAll(BeneficiaryFilter filter)
        {
            try
            {
                IOperationResultList<BeneficiaryDto> ressul = await _beneficiaryRepository.All
                    .Include(e => e.Person)
                    .Where(GetFilters(filter)).ToResultListAsync<Beneficiary, BeneficiaryDto>(Offset: filter.Offset, Take: filter.Take);
                return ressul;
            }
            catch (Exception ex)
            {
                return await ex.ToResultListAsync<BeneficiaryDto>();
            }

        }

        public async Task<IOperationResult<BeneficiaryDto>> GetById(int id)
        {
            try
            {
                Beneficiary? entidad = await _beneficiaryRepository.All
                    .Include(e => e.Person)
                    .Where(e => e.Active && e.Person.Id == id && e.Person.Active == e.Active)
                    .FirstOrDefaultAsync();
                if (entidad == null)
                {
                    return new OperationResult<BeneficiaryDto>(System.Net.HttpStatusCode.NotFound, "No se encontro el beneficiario");
                }
                return await entidad.ToResultAsync<Beneficiary, BeneficiaryDto>();

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync<BeneficiaryDto>();
            }
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<BeneficiaryRequest> entity)
        {
            try
            {
                Beneficiary? beneficiario = await _beneficiaryRepository.All
                    .Include(e => e.Person)
                    .Where(e => e.Active && e.Person.Id == id && e.Person.Active == e.Active)
                    .FirstOrDefaultAsync();
                if (beneficiario == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "No se encontro el beneficiario");
                }
                entity.Data.Person.GetNameCompleted();

                Beneficiary request = beneficiario.MapTo<Beneficiary>(entity.Data);
                if (await IsExitByIdentificationUpdate(entity.Data, id))
                {
                    return new OperationResult(System.Net.HttpStatusCode.Conflict, "Ya existe un beneficiario con la misma identificacion");
                }
                request.Person.Beneficiary = request;

                await _personRepository.UpdateAsync(request.Person);
                await _personRepository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.OK, "El beneficiario fue actualizado con exito");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }
    }
}
