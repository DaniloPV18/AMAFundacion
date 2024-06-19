using FundacionAMA.Domain.DTO.Catalogo.Dto;
using FundacionAMA.Domain.DTO.Catalogo.Filter;
using FundacionAMA.Domain.DTO.Catalogo.Request;



namespace FundacionAMA.Domain.Services
{
    internal class DonationTypeService : IDonationTypeService
    {
        private readonly IDonationTypeRepository _repository;

        public DonationTypeService(IDonationTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<DonationTypeRequest> entity)
        {
            try
            {
                DonationType entidad = entity.Data.MapTo<DonationType>();
                await _repository.InsertAsync(entidad);
                await _repository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.Created, $"el tipo tipo de donacion {entity.Data.Name} se creo correctamente");

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
                DonationType? entidad = await _repository.All.Where(e => e.Active && e.Id == id.Data).FirstOrDefaultAsync();
                if (entidad == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, $"el tipo de donacion con id {id.Data} no existe");
                }
                await _repository.DeleteAsync(entidad);
                await _repository.SaveChangesAsync(id);
                return new OperationResult(System.Net.HttpStatusCode.OK, $"el tipo de donacion con id {id.Data} se elimino correctamente");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public async Task<IOperationResultList<DonationTypeDto>> GetAll(DonationTypeFilter filter)
        {
            try
            {
                IOperationResultList<DonationTypeDto> query = await _repository.All.Where(e => e.Active)
                    .ToResultListAsync<DonationType, DonationTypeDto>(Offset: filter.Take, Take: filter.Offset);
                return query;

            }
            catch (Exception ex)
            {
                return await ex.ToResultListAsync<DonationTypeDto>();
            }
        }

        public async Task<IOperationResult<DonationTypeDto>> GetById(int id)
        {
            try
            {
                DonationType? entidad = await _repository.All.Where(e => e.Active && e.Id == id)
                    .FirstOrDefaultAsync();
                return entidad == null
                    ? new OperationResult<DonationTypeDto>(System.Net.HttpStatusCode.NotFound, $"el tipo de donacion con id {id} no existe")
                    : await entidad.ToResultAsync<DonationType, DonationTypeDto>();
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync<DonationTypeDto>();
            }
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<DonationTypeRequest> entity)
        {
            try
            {
                DonationType? entidad = await _repository.All.Where(e => e.Active && e.Id == id).FirstOrDefaultAsync();
                if (entidad == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, $"el tipo de donacion con id {id} no existe");
                }

                entidad = entidad.MapTo<DonationType>(entity.Data);
                await _repository.UpdateAsync(entidad);
                await _repository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.OK, $"el tipo de donacion con id {id} se actualizo correctamente");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }
    }
}
