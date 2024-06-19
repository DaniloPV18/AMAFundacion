using FundacionAMA.Domain.DTO.Catalogo.Dto;
using FundacionAMA.Domain.DTO.Catalogo.Filter;
using FundacionAMA.Domain.DTO.Catalogo.Request;

namespace FundacionAMA.Domain.Interfaces.Services
{
    public interface IDonationTypeService : ICrudService<IOperationRequest<DonationTypeRequest>, DonationTypeDto, DonationTypeFilter, int>
    {
    }
}
