namespace FundacionAMA.Domain.DTO.Donor.Request
{
    public class DonorResquest
    {
        public int PersonId { get; set; }

        public string Identificacion { get; set; }

        public string NombreCompleto { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Status { get; set; }
    }
}
