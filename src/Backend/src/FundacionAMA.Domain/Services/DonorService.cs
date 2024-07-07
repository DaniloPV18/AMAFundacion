using FundacionAMA.Domain.DTO.Donor.Dto;
using FundacionAMA.Domain.DTO.Donor.Filter;
using FundacionAMA.Domain.DTO.Donor.Request;

using Microsoft.EntityFrameworkCore;

namespace FundacionAMA.Domain.Services
{
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository _repository;

        public DonorService(IDonorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<DonorResquest> entity)
        {
            try
            {
                Donor donorEntity = entity.Data.MapTo<Donor>();
                await _repository.InsertAsync(donorEntity);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.Created, "Donante creado con exito");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public Task<IOperationResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            throw new NotImplementedException();
        }

        public async Task<IOperationResultList<DonorDto>> GetAll(DonorFilter filter)
        {
            try
            {
                IOperationResultList<DonorDto> entidad = await _repository
                    .All.Where(e => e.Active)
                    .ToResultListAsync<Donor, DonorDto>(Offset: filter.Offset, Take: filter.Take);
                return entidad;
            }
            catch (Exception ex)
            {
                return await ex.ToResultListAsync<DonorDto>();
            }
        }

        public async Task<IOperationResult<DonorDto>> GetById(int id)
        {
            try
            {
                Donor? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.PersonId == id);
                return entidad == null
                    ? new OperationResult<DonorDto>(System.Net.HttpStatusCode.NotFound, "Donante no encontrado")
                    : await entidad.ToResultAsync<Donor, DonorDto>();

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync<DonorDto>();
            }
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<DonorResquest> entity)
        {
            try
            {
                Donor? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.PersonId == id);
                if (entidad == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "Donante no encontrado");
                }
                entidad = entidad.MapTo<Donor>(entity.Data);
                await _repository.UpdateAsync(entidad);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "Donante actualizado correctamente");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }
    }
}

