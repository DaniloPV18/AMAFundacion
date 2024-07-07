using FundacionAMA.Domain.Shared.Interfaces;

using System.ComponentModel.DataAnnotations;

namespace FundacionAMA.Domain.Shared.Entities;
public class BaseEntity<T> : BaseEntity
{
    [Key]

    public required T Id { get; set; }
}
public class BaseEntity : AuditEntity, IEntity
{
    public bool Active { get; set; }

}