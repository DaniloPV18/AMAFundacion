namespace FundacionAMA.Domain.DTO.Catalogo.Request
{
    public class TypeIdentificationRequest
    {
        public int? CompanyId { get; set; }

        public required string Code { get; set; }

        public required string Description { get; set; }
    }
}
