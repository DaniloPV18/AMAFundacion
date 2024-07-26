using FundacionAMA.Domain.DTO.Person.Request;

namespace FundacionAMA.Domain.DTO.Person
{
    /// <summary>
    /// Dto de persona
    /// </summary>
    public class PersonDto : PersonRequest
    {
        /// <summary>
        /// Id de la persona
        /// </summary>
        public int Id { get; set; }
        public string Identification { get; set; }
        public string NameCompleted { get; set; }
        public string Email { get; set; }
    }
}
