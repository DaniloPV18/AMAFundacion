using FundacionAMA.Domain.DTO.Donation.Dto;
using FundacionAMA.Domain.DTO.Donation.Filter;
using FundacionAMA.Domain.DTO.Donation.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Application.Services.DonationApp
{
    public interface IDonationServiceApp : ICrudService<IOperationRequest<DonationRequest>, DonationDto, DonationFilter, int>
    {
    }
}
