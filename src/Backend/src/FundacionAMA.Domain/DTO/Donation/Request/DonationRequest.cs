namespace FundacionAMA.Domain.DTO.Donation.Request
{
    /// <summary>
    /// Request de Donacion
    /// </summary>
    public class DonationRequest
    {
        /// <summary>
        /// nombre de la donacion
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// tipo de donacion
        /// </summary>
        public int? DonationTypeId { get; set; }
        /// <summary>
        /// precio de la donacion
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// total de la donacion
        /// </summary>
        public decimal? Total { get; set; }
        /// <summary>
        /// persona donante
        /// </summary>

        public int? PersonId { get; set; }
        /// <summary>
        /// brigada a la que pertenece
        /// </summary>

        public int? BrigadeId { get; set; }
        /// <summary>
        /// status de la donacion
        /// </summary>
        public string? Status { get; set; }
        /// <summary>
        /// Catnitdad de donaciones
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// Fecha de donacion
        /// </summary>
        public DateTime AssignedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Obtener total del precio por la cantidad de donaciones
        /// </summary>
        public void GetTotal()
        {
            Total = Price * Amount;
        }

    }
}
