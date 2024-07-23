namespace FundacionAMA.Domain.DTO.Brigade.Dto
{
    public class BrigadeDto : BrigadeRequest
    {
        /// <summary>
        /// identificador de la brigada
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// identificador de la persona
        /// </summary>
        public string? IdentificationPerson { get; set; }
        /// <summary>
        /// nombre de la persona
        /// </summary>
        public string? NameCompletedPerson { get; set; }

    }
}
