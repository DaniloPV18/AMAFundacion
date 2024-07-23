using FundacionAMA.Domain.Shared.Entities;

using System.ComponentModel.DataAnnotations.Schema;

namespace FundacionAMA.Domain.Entities;

[Table("Users")]
public class User : BaseEntity<int>
{
    public required string Identification { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public string Salt { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public string? TempCode { get; set; } = string.Empty;

    public DateTime? TempCodeCreateAt { get; set; }

    public virtual ICollection<CompanyUser> CompanyUsers { get; set; } = new List<CompanyUser>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}