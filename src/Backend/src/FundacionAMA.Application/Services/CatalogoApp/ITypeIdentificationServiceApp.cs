using FundacionAMA.Domain.DTO.Catalogo.Dto;
using FundacionAMA.Domain.DTO.Catalogo.Filter;
using FundacionAMA.Domain.DTO.Catalogo.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Application.Services.CatalogoApp
{
    public interface ITypeIdentificationServiceApp :
        ICrudService<IOperationRequest<TypeIdentificationRequest>,
            TypeIdentificationDto, TypeIdentificationFilter, short>
    {
    }
}
