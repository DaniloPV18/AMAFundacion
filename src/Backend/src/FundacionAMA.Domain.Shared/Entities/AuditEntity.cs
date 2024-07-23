using FundacionAMA.Domain.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FundacionAMA.Domain.Shared.Entities;

public class AuditEntity : IAudit
{
    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public int CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public int? UpdatedBy { get; set; }
}
