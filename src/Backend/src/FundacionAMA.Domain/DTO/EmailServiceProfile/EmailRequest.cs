using System.ComponentModel.DataAnnotations;

namespace FundacionAMA.Domain.DTO.EmailServiceProfile;

public class EmailRequest
{

    [Required]
    public int ProfileId { get; set; }

    [Required]
    public required string[] To { get; set; }


    public string[]? Cc { get; set; }
    public string[]? Bcc { get; set; }
    [Required]
    public string Subject { get; set; } = string.Empty;

    [Required]
    public string Body { get; set; } = string.Empty;


    [Required]
    public bool IsHTML { get; set; }

    public List<Attachment>? Attachments { get; set; }
}
