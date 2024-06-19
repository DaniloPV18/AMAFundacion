using FundacionAMA.Domain.DTO.Volunteer.Dto;
using FundacionAMA.Domain.DTO.Volunteer.Filter;
using FundacionAMA.Domain.DTO.Volunteer.Request;
using FundacionAMA.Domain.DTO.Donor.Request;
using Microsoft.EntityFrameworkCore;

namespace FundacionAMA.Domain.Services
{
    internal class VolunteerService : IVolunteerService
    {
        public readonly IVolunteerRepository _repository;

        public VolunteerService(IVolunteerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<VolunteerRequest> entity)
        {
            try
            {
                Volunteer dVolunteerEntiy = entity.Data.MapTo<Volunteer>();
                await _repository.InsertAsync(dVolunteerEntiy);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.Created, "Voluntario creado con éxito");

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
                Volunteer? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.PersonId == id.Data);

                if (entidad == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "Voluntario no encontrado");
                }

                await _repository.DeleteAsync(entidad);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "Voluntario eliminado con éxito");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public async Task<IOperationResultList<VolunteerDto>> GetAll(VolunteerFilter filter)
        {
            try
            {
                IOperationResultList<VolunteerDto> entidad = await _repository
                    .All.Where(e => e.Active)
                    .ToResultListAsync<Volunteer, VolunteerDto>(Offset: filter.Offset, Take: filter.Take);

                return entidad;

            }
            catch (Exception ex)
            {
                return await ex.ToResultListAsync<VolunteerDto>();
            }
        }

        public async Task<IOperationResult<VolunteerDto>> GetById(int id)
        {
            try
            {
                Volunteer? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.PersonId == id);
                return entidad == null
                    ? new OperationResult<VolunteerDto>(System.Net.HttpStatusCode.NotFound, "Voluntario no encontrado")
                    : await entidad.ToResultAsync<Volunteer, VolunteerDto>();
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync<VolunteerDto>();
            }
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<VolunteerRequest> entity)
        {
            try
            {
                Volunteer? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.PersonId == id);
                if (entidad == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "Voluntario no encontrado");
                }

                entidad = entidad.MapTo<Volunteer>(entity.Data);

                await _repository.UpdateAsync(entidad);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "Voluntario actualizado con éxito");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }

        }
    }
}

