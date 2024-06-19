using FundacionAMA.Domain.DTO.Donor.Filter;
using FundacionAMA.Domain.DTO.Donor.Request;


namespace FundacionAMA.Domain.Interfaces.Controller.Donor
{
    public interface IDonorController : ICrudController<DonorResquest, DonorFilter, int>
    {
    }
}
