using FundacionAMA.Domain.DTO.Catalogo.Dto;
using FundacionAMA.Domain.DTO.Catalogo.Filter;
using FundacionAMA.Domain.DTO.Catalogo.Request;

namespace FundacionAMA.Domain.Services
{
    internal class TypeIdentificationService : ITypeIdentificationService
    {
        private readonly ITypeIdentificationRepository _repository;

        public TypeIdentificationService(ITypeIdentificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<TypeIdentificationRequest> entity)
        {
            try
            {
                IdentificationType entityDto = entity.Data.MapTo<IdentificationType>();

                await _repository.InsertAsync(entityDto);
                await _repository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.Created, "tipo de identificación creado con éxito");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public async Task<IOperationResult> Delete(IOperationRequest<short> id)
        {
            try
            {
                IdentificationType? entityDto = await _repository.GetByIdAsync(id.Data);
                if (entityDto == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "tipo de identificación no encontrado");
                }

                await _repository.DeleteAsync(entityDto);
                await _repository.SaveChangesAsync(id);
                return new OperationResult(System.Net.HttpStatusCode.OK, "tipo de identificación eliminado con éxito");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public async Task<IOperationResultList<TypeIdentificationDto>> GetAll(TypeIdentificationFilter filter)
        {
            try
            {
                IOperationResultList<TypeIdentificationDto> result = await _repository.All
                    .Where(e => e.Active).ToResultListAsync<IdentificationType, TypeIdentificationDto>();
                return result;
            }
            catch (Exception ex)
            {
                return await ex.ToResultListAsync<TypeIdentificationDto>();
            }
        }

        public async Task<IOperationResult<TypeIdentificationDto>> GetById(short id)
        {
            try
            {
                IdentificationType? result = await _repository.GetByIdAsync(id);
                return result == null
                    ? new OperationResult<TypeIdentificationDto>(System.Net.HttpStatusCode.NotFound, "tipo de identificación no encontrado")
                    : await result.ToResultAsync<IdentificationType, TypeIdentificationDto>();
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync<TypeIdentificationDto>();
            }
        }

        public async Task<IOperationResult> Update(short id, IOperationRequest<TypeIdentificationRequest> entity)
        {
            try
            {
                IdentificationType? enti = await _repository.GetByIdAsync(id);
                if (enti == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "tipo de identificación no encontrado");
                }
                enti = entity.MapTo<IdentificationType>(entity.Data);
                await _repository.UpdateAsync(enti);
                await _repository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.OK, "tipo de identificación actualizado con éxito");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }
    }
}
