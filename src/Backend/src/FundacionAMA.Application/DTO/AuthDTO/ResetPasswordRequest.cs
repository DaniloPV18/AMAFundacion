namespace FundacionAMA.Application.DTO.AuthDTO;

public class ResetPasswordRequest
{
    public string Identification { get; set; }
    public string Code { get; set; }
    public string Password { get; set; }
}
