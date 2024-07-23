using FundacionAMA.Domain.Shared.Entities.Dtos;

namespace FundacionAMA.Domain.DTO.Donation.Filter
{
    public class DonationFilter : RequestPaginated
    {
        /// <summary>
        /// Nombre de la donacion
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// tipo de donacion
        /// </summary>
        public int? DonationTypeId { get; set; }
        public int? Id { get; set; }

        /// <summary>
        /// persona que dona
        /// </summary>
        public int? PersonId { get; set; }
        /// <summary>
        /// brigada que recibe la donacion
        /// </summary>
        public int? BrigadeId { get; set; }
    }
}
