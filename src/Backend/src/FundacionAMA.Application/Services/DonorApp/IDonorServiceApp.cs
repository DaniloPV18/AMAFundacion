using FundacionAMA.Domain.DTO.Donor.Dto;
using FundacionAMA.Domain.DTO.Donor.Filter;
using FundacionAMA.Domain.DTO.Donor.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Application.Services.DonorApp
{
    public interface IDonorServiceApp : ICrudService<IOperationRequest<DonorResquest>, DonorDto, DonorFilter, int>
    {

    }
}
