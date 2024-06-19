using FundacionAMA.Domain.DTO.Catalogo.Dto;
using FundacionAMA.Domain.DTO.Catalogo.Filter;
using FundacionAMA.Domain.DTO.Catalogo.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Application.Services.CatalogoApp
{
    internal class TypeIdentificationServiceApp : ITypeIdentificationServiceApp
    {
        private readonly ITypeIdentificationService _typeIdentificationService;

        public TypeIdentificationServiceApp(ITypeIdentificationService typeIdentificationService)
        {
            _typeIdentificationService = typeIdentificationService;
        }

        public Task<IOperationResult> Create(IOperationRequest<TypeIdentificationRequest> entity)
        {
            return _typeIdentificationService.Create(entity);
        }

        public Task<IOperationResult> Delete(IOperationRequest<short> id)
        {
            return _typeIdentificationService.Delete(id);
        }

        public Task<IOperationResultList<TypeIdentificationDto>> GetAll(TypeIdentificationFilter filter)
        {
            return _typeIdentificationService.GetAll(filter);
        }

        public Task<IOperationResult<TypeIdentificationDto>> GetById(short id)
        {
            return _typeIdentificationService.GetById(id);
        }

        public Task<IOperationResult> Update(short id, IOperationRequest<TypeIdentificationRequest> entity)
        {
            return _typeIdentificationService.Update(id, entity);
        }
    }
}
