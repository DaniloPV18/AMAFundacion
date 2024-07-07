using FundacionAMA.Domain.DTO.Donation.Filter;
using FundacionAMA.Domain.DTO.Donation.Request;

namespace FundacionAMA.Domain.Interfaces.Controller.Donation
{

    public interface IDonationController : ICrudController<DonationRequest, DonationFilter, int>
    {
    }
}
