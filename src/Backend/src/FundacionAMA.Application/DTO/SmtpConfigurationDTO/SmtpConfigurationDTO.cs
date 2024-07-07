namespace FundacionAMA.Application.DTO.SmtpConfigurationDTO;

public class SmtpConfigurationDTO
{
    public int Id { get; set; }
    public int Profile { get; set; }
    public string Mail { get; set; }
    public string DisplayName { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public bool Authenticate { get; set; }
}
