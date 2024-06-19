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
    }
}
