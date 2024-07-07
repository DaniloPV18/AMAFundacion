using FundacionAMA.Domain.DTO.Brigade.Dto;
using FundacionAMA.Domain.DTO.Brigade.FilterDto;
using FundacionAMA.Domain.DTO.Brigade.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Application.Services.BrigadeApp
{
    public interface IBrigadeAppService : ICrudService<IOperationRequest<BrigadeRequest>, BrigadeDto, BrigadeFilter, int>
    {
    }
}
