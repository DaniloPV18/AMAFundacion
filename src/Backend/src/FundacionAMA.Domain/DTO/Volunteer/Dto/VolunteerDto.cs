using FundacionAMA.Domain.DTO.Person;
using FundacionAMA.Domain.DTO.Volunteer.Request;

namespace FundacionAMA.Domain.DTO.Volunteer.Dto
{
    public class VolunteerDto : VolunteerRequest
    {
        public required int Id { get; set; }
        public virtual PersonDto? Person { get; set; }
    }
}

