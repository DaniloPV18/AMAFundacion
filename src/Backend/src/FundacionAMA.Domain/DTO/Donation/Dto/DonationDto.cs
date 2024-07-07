using FundacionAMA.Domain.DTO.Donation.Request;

namespace FundacionAMA.Domain.DTO.Donation.Dto
{
    /// <summary>
    /// Dto de Donacion
    /// </summary>
    public class DonationDto : DonationRequest
    {
        public required int Id { get; set; }
        public required string DonationType { get; set; }
        public required string NameBrigade { get; set; }
        public required string IdentificationPerson { get; set; }
        public required string NameCompletedPerson { get; set; }
    }
}
