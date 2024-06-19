namespace FundacionAMA.Domain.DTO.Catalogo.Request
{
    public class DonationTypeRequest
    {
        public int? CompanyId { get; set; }

        public required string Name { get; set; }

        public required string Status { get; set; }

    }
}
