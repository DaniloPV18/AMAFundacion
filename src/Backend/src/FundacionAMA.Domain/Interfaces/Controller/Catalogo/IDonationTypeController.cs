using FundacionAMA.Domain.DTO.Catalogo.Filter;
using FundacionAMA.Domain.DTO.Catalogo.Request;

namespace FundacionAMA.Domain.Interfaces.Controller.Catalogo
{
    public interface IDonationTypeController : ICrudController<DonationTypeRequest, DonationTypeFilter, int>
    {
    }
}
