using System.ComponentModel.DataAnnotations;

namespace FundacionAMA.Application.DTO.UserDTO;

public class UserRequest
{
    [Required]
    public string? Identification { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }
}
