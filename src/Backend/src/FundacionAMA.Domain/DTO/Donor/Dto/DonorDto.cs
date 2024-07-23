using FundacionAMA.Domain.DTO.Donor.Request;
using FundacionAMA.Domain.DTO.Person;

namespace FundacionAMA.Domain.DTO.Donor.Dto
{
    public class DonorDto : DonorResquest
    {
        public required int ID { get; set; }
        public PersonDto? Person { get; set; }

    }
}
