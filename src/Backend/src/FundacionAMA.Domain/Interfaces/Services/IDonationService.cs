using FundacionAMA.Domain.DTO.Donation.Dto;
using FundacionAMA.Domain.DTO.Donation.Filter;
using FundacionAMA.Domain.DTO.Donation.Request;

namespace FundacionAMA.Domain.Interfaces.Services
{
    public interface IDonationService : ICrudService<IOperationRequest<DonationRequest>, DonationDto, DonationFilter, int>
    {
    }
}
