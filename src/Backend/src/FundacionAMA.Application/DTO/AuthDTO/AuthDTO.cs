namespace FundacionAMA.Application.DTO.AuthDTO;

public class AuthDTO
{
    public AuthDTO(string token, DateTimeOffset date)
    {
        Token = token;
        Autenticate = !string.IsNullOrEmpty(Token);

        if (Autenticate)
            Message = "successfully authenticated";
        else
            Message = "Incorrect username or password";

        Date = date;
    }

    public AuthDTO(string message)
    {
        Token = string.Empty;
        Autenticate = false;
        if (string.IsNullOrEmpty(message))
            Message = "Incorrect username or password";
        else
            Message = message;

    }
    public AuthDTO()
    {
        Token = string.Empty;
        Autenticate = false;
        Message = "Incorrect username or password";

    }
    public bool Autenticate { get; set; }
    public string Message { get; set; }
    public string Token { get; set; }
    public DateTimeOffset Date { get; set; }
}
