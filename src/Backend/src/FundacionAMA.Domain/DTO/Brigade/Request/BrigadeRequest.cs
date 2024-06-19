using System.ComponentModel.DataAnnotations;

namespace FundacionAMA.Domain.DTO.Brigade.Request
{
    /// <summary>
    /// recibe los datos de la brigada
    /// </summary>
    public class BrigadeRequest
    {
        /// <summary>
        /// id de compañia
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// ide de persona
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La propiedad debe ser mayor a 0")]
        public int PersonId { get; set; }

        /// <summary>
        /// Nombre de la brigada
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Descripcion de la brigada
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Fecha de inicio de la brigada
        /// </summary>
        public required DateTime Start { get; set; }

        /// <summary>
        /// Fecha de fin de la brigada
        /// </summary>
        public required DateTime End { get; set; }
    }
}
