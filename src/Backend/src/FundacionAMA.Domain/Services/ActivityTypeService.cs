using FundacionAMA.Domain.DTO.ActivityType.Dto;
using FundacionAMA.Domain.DTO.ActivityType.FilterDto;
using FundacionAMA.Domain.DTO.ActivityType.Request;
using FundacionAMA.Domain.DTO.ActivityType.Dto;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using Microsoft.EntityFrameworkCore;


namespace FundacionAMA.Domain.Services
{
    internal class ActivityTypeService : IActivityTypeService
    {
        private readonly IActivityTypeRepository _repository;

        public ActivityTypeService(IActivityTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<ActivityTypeRequest> entity)
        {

            try
            {

                var request = entity.Data.MapTo<ActivityType>();
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

        public async Task<IOperationResultList<ActivityTypeDto>> GetAll(IOperationRequest<ActivityTypeFilter> filter)
        {
            try
            {

                var Donante = await _repository.ToResultListPaginatedAscyn<ActivityTypeDto>(filter.Data.Offset, filter.Data.Take);

                return Donante;
            }
            catch (Exception ex)
            {

                return await ex.ToResultListAsync<ActivityTypeDto>();
            }
        }

        public async Task<IOperationResult<ActivityTypeDto>> GetById(int id)
        {
            try
            {

                var brigada = await _repository.GetByIdAsync(id);
                if (brigada == null)
                    return new OperationResult<ActivityTypeDto>(System.Net.HttpStatusCode.NotFound, "No se encontro la brigada");

                return await brigada.ToResultAsync<ActivityType, ActivityTypeDto>();

            }
            catch (Exception ex)
            {

                return await ex.ToResultAsync<ActivityTypeDto>();
            }
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<ActivityTypeRequest> entity)
        {
            try
            {

                var brigara = await _repository.GetByIdAsync(id);
                if (brigara == null)
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "No se encontro el donante");

                var request = entity.Data.MapTo<ActivityType>(brigara);
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
