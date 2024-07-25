using System.Linq.Expressions;

namespace FundacionAMA.Domain.Services
{
    internal class BrigadeService : IBrigadeService
    {
        private readonly IBrigadeRepository _brigadeRepository;
        private readonly ILogger<BrigadeService> _logger;

        public BrigadeService(IBrigadeRepository brigadeRepository, ILogger<BrigadeService> logger)
        {
            _brigadeRepository = brigadeRepository;
            _logger = logger;
        }

        public Task<IOperationResult> Create(IOperationRequest<BrigadeRequest> entity)
        {
            try
            {
                _logger.LogInformation("Creando brigada");
                Brigade request = entity.Data.MapTo<Brigade>();
                _ = _brigadeRepository.InsertAsync(request);
                _ = _brigadeRepository.SaveChangesAsync(entity);
                _logger.LogInformation("Brigada creada con exito");
                return new Task<IOperationResult>(() => new OperationResult(System.Net.HttpStatusCode.Created, "la brigada fue creada con exito"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear brigada");
                return ex.ToResultAsync();
            }
        }

        public async Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            try
            {
                _logger.LogInformation("Eliminando brigada");
                Brigade? brigada = await _brigadeRepository.GetByIdAsync(id.Data);
                if (brigada == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "No se encontro la brigada");
                }
                await _brigadeRepository.DeleteAsync(brigada);
                await _brigadeRepository.SaveChangesAsync(id);
                _logger.LogInformation("Brigada eliminada con exito");
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "La brigada fue eliminada con exito");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar brigada");
                return await ex.ToResultAsync();
            }
        }

        public Task<IOperationResultList<BrigadeDto>> GetAll(BrigadeFilter filter)
        {
            try
            {
                _logger.LogInformation("Obteniendo brigadas");
                Task<IOperationResultList<BrigadeDto>> brigada = _brigadeRepository
                    .All
                    .Where(GetFilterBrigade(filter))
                    .ToResultListAsync<Brigade, BrigadeDto>(filter.Offset, filter.Take);
                _logger.LogInformation("Brigadas obtenidas con exito");
                return brigada;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener brigadas");
                return ex.ToResultListAsync<BrigadeDto>();
            }
        }

        private static Expression<Func<Brigade, bool>> GetFilterBrigade(BrigadeFilter filter)
        {
            return e => e.Active && (
                        (string.IsNullOrWhiteSpace(filter.Description) || e.Description.Contains(filter.Description)) &&
                        (string.IsNullOrWhiteSpace(filter.Name) || e.Name.Contains(filter.Name)) &&
                        (filter.CompanyId == null || e.CompanyId == filter.CompanyId) &&
                        (!filter.Start.HasValue || e.Start == filter.Start) &&
                        (!filter.End.HasValue || e.End == filter.End) &&
                        (filter.PersonId == null || e.PersonId == filter.PersonId) &&
                        (filter.Id == null || e.Id == filter.Id));
        }

        public async Task<IOperationResult<BrigadeDto>> GetById(int id)
        {
            try
            {
                _logger.LogInformation("Obteniendo brigada");
                Brigade? brigada = await _brigadeRepository.GetByIdAsync(id);
                if (brigada == null)
                {
                    return new OperationResult<BrigadeDto>(System.Net.HttpStatusCode.NotFound, "No se encontro la brigada");
                }

                _logger.LogInformation("Brigada obtenida con exito");
                return await brigada.ToResultAsync<Brigade, BrigadeDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener brigada");
                return await ex.ToResultAsync<BrigadeDto>();
            }
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<BrigadeRequest> entity)
        {
            try
            {
                _logger.LogInformation("Actualizando brigada");
                Brigade? brigara = await _brigadeRepository.GetByIdAsync(id);
                if (brigara == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "No se encontro la brigada");
                }

                Brigade request = entity.Data.MapTo<Brigade>(brigara);
                await _brigadeRepository.UpdateAsync(request);
                _logger.LogInformation("Brigada actualizada con exito");
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "La brigada fue actualizada con exito");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar brigada");
                return await ex.ToResultAsync();
            }
        }
    }
}