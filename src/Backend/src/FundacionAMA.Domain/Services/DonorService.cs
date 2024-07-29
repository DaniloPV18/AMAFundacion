using FundacionAMA.Domain.DTO.Donor.Dto;
using FundacionAMA.Domain.DTO.Donor.Filter;
using FundacionAMA.Domain.DTO.Donor.Request;
using FundacionAMA.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace FundacionAMA.Domain.Services
{
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository _repository;
        private readonly IPersonRepository _personRepository;

        public DonorService(IDonorRepository repository, IPersonRepository personRepository)
        {
            _repository = repository;
            _personRepository = personRepository;
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
      
        public async Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            try
            {
                Donor? donor = await _repository.All
                    .Include(e => e.Person)
                    .FirstOrDefaultAsync(e => e.Active && e.Person.Id == id.Data && e.Person.Active == e.Active);

                if (donor == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "No se encontro el donante");
                }
                await _repository.DeleteAsync(donor);
                await _personRepository.DeleteDonorPerson(donor.Person);
                await _repository.SaveChangesAsync(id);
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "El donante fue eliminado con exito");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }

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

        public async Task<IOperationResult<DonorDto>> GetByIdentification(string identification)
        {
            try
            {
                Donor? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.PersonIdentification == identification);
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

