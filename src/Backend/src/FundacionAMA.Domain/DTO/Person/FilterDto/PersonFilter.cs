using FundacionAMA.Domain.Shared.Entities.Dtos;

namespace FundacionAMA.Domain.DTO.Person.FilterDto
{
    /// <summary>
    /// Filtro de personas
    /// </summary>
    public class PersonFilter : RequestPaginated
    {
        /// <summary>
        /// donante verdadero o falso
        /// </summary>
        public bool? Donor { get; set; }

        /// <summary>
        /// Correo de la persona
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// identificacion de la persona
        /// </summary>
        public string? Identification { get; set; }
        /// <summary>
        /// Apellido de la persona
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// nombre de la persona
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Telefono de la persona
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// voluntario verdadero o falso
        /// </summary>
        public bool? Volunteer { get; set; }
        public string? FirstName { get; set; }
    }
}
