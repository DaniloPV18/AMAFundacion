using FundacionAMA.Domain.Shared.Entities.Dtos;

namespace FundacionAMA.Domain.DTO.Volunteer.Filter
{
    public class VolunteerFilter : RequestPaginated
    {
        public string? Identificacion { get; set; }
    }
}
