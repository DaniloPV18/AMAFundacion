using FundacionAMA.Domain.Shared.Entities.Dtos;

namespace FundacionAMA.Domain.DTO.Brigade.FilterDto
{
    /// <summary>
    ///  filtro de brigada
    /// </summary>
    public class BrigadeFilter : RequestPaginated
    {
        /// <summary>
        /// company id
        /// </summary>
        public int? CompanyId { get; set; }
        /// <summary>
        /// person id
        /// </summary>
        public int? PersonId { get; set; }
        /// <summary>
        /// nombre de la brigada
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// descripcion de la brigada
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// fecha de inicio  de la brigada
        /// </summary>
        public DateTime? Start { get; set; }
        /// <summary>
        /// fecha  fin de la brigada
        /// </summary>
        public DateTime? End { get; set; }
        public int? Id { get; set; }
    }
}
