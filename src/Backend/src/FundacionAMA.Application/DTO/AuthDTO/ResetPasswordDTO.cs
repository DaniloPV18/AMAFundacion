namespace FundacionAMA.Application.DTO.AuthDTO
{
    public class ResetPasswordDTO
    {
        public ResetPasswordDTO(bool success, string message)
        {
            this.success = success;
            this.message = message;
        }
        public bool success { get; set; }
        public string message { get; set; }


    }
}
