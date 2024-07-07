using FundacionAMA.Domain.DTO.Donation.Dto;
using FundacionAMA.Domain.DTO.Donation.Filter;
using FundacionAMA.Domain.DTO.Donation.Request;

namespace FundacionAMA.Domain.Services
{
    internal class DonationService : IDonationService
    {
        public readonly IDonationRepository _repository;

        public DonationService(IDonationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<DonationRequest> entity)
        {
            try
            {
                entity.Data.GetTotal();
                Donation donacionEntiy = entity.Data.MapTo<Donation>();
                await _repository.InsertAsync(donacionEntiy);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.Created, "Donacion creado con éxito");

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
                Donation? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id.Data);

                if (entidad == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "Donacion no encontrado");
                }

                await _repository.DeleteAsync(entidad);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "Donacion eliminado con éxito");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public async Task<IOperationResultList<DonationDto>> GetAll(DonationFilter filter)
        {
            try
            {
                IOperationResultList<DonationDto> entidad = await _repository

                    .All
                    .Include(e => e.DonationType)
                    .Where(
                    e => e.Active
                    && (string.IsNullOrWhiteSpace(filter.Name) || e.Name.Contains(filter.Name))

                    && (filter.PersonId == null || e.PersonId == filter.PersonId)
                    && (filter.Id == null || e.Id == filter.Id)
                    && (filter.BrigadeId == null || e.PersonId == filter.BrigadeId)
                    && (filter.DonationTypeId == null || e.DonationTypeId == filter.DonationTypeId)

                    )
                    .ToResultListAsync<Donation, DonationDto>(Offset: filter.Offset, Take: filter.Take);

                return entidad;

            }
            catch (Exception ex)
            {
                return await ex.ToResultListAsync<DonationDto>();
            }
        }

        public async Task<IOperationResult<DonationDto>> GetById(int id)
        {
            try
            {
                Donation? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id);
                return entidad == null
                    ? new OperationResult<DonationDto>(System.Net.HttpStatusCode.NotFound, "Donacion no encontrado")
                    : await entidad.ToResultAsync<Donation, DonationDto>();
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync<DonationDto>();
            }
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<DonationRequest> entity)
        {
            try
            {
                entity.Data.GetTotal();

                Donation? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id);
                if (entidad == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "Donacion no encontrado");
                }

                entidad = entidad.MapTo<Donation>(entity.Data);

                await _repository.UpdateAsync(entidad);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "Donacion actualizado con éxito");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }

        }
    }
}
