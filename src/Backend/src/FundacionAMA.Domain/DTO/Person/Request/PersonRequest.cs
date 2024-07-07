using FundacionAMA.Domain.DTO.Beneficiary.Request;
using FundacionAMA.Domain.DTO.Volunteer.Request;

namespace FundacionAMA.Domain.DTO.Person.Request
{
    public class PersonRequestHeader
    {
        /// <summary>
        /// Correo de la persona
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// perimer nombre de la persona
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// identificacion de la persona
        /// </summary>
        public string Identification { get; set; }
        /// <summary>
        /// Id del tipo de identificacion
        /// </summary>
        public short? IdentificationTypeId { get; set; }
        /// <summary>
        /// Apellido de la persona
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// nombre de la persona
        /// </summary>
        public string? NameCompleted { get; set; }
        /// <summary>
        /// telefono de la persona
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// segundo apellido de la persona
        /// </summary>
        public string? SecondLastName { get; set; }
        /// <summary>
        /// segundo nombre de la persona
        /// </summary>
        public string? SecondName { get; set; }
        /// <summary>
        /// status de la persona
        /// </summary>
        public string? Status { get; set; }
        public void GetNameCompleted()
        {
            NameCompleted = string.Format("{0} {1} {2} {3}",
               (!String.IsNullOrEmpty(FirstName) ? FirstName : string.Empty),
               (!String.IsNullOrEmpty(SecondName) ? SecondName : string.Empty),
               (!String.IsNullOrEmpty(LastName) ? LastName : string.Empty),
               (!String.IsNullOrEmpty(SecondName) ? SecondName : string.Empty).Trim());
        }
    }
    /// <summary>
    /// Request de persona
    /// </summary>
    public class PersonRequest : PersonRequestHeader
    {
        /// <summary>
        /// donante verdadero o falso
        /// </summary>
        public bool Donor { get; set; } = false;

        /// <summary>
        /// voluntario verdadero o falso
        /// </summary>
        public bool Volunteer { get; set; } = false;
        /// <summary>
        /// request de beneficiario
        /// </summary>
        public BeneficiaryRequest? Beneficiary { get; set; }

        /// <summary>
        /// request de voluntario
        /// </summary>
        public VolunteerRequest? volunaterRequest { get; set; }
        /// <summary>
        /// Metodo para obtener el nombre completo
        /// </summary>

    }
}