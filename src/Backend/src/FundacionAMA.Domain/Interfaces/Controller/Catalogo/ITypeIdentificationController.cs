using FundacionAMA.Domain.DTO.Catalogo.Filter;
using FundacionAMA.Domain.DTO.Catalogo.Request;

namespace FundacionAMA.Domain.Interfaces.Controller.Catalogo
{
    public interface ITypeIdentificationController : ICrudController<TypeIdentificationRequest, TypeIdentificationFilter, short>
    {
    }
}
