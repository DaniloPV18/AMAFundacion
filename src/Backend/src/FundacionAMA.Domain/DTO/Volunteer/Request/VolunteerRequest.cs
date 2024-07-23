namespace FundacionAMA.Domain.DTO.Volunteer.Request
{
    /// <summary>
    /// request de voluntarios
    /// </summary>
    public class VolunteerRequest
    {
        public int PersonId { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string Status { get; set; }

        public bool Availability { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ActivityTypeId { get; set; }




    }
}
