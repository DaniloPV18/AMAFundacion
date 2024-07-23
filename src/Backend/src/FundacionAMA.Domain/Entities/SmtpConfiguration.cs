using FundacionAMA.Domain.Shared.Entities;

using System.ComponentModel.DataAnnotations.Schema;

namespace FundacionAMA.Domain.Entities;

[Table("SmtpConfigurations")]
public class SmtpConfiguration : BaseEntity<int>
{


    public int? CompanyId { get; set; }

    public int Profile { get; set; }

    public string Mail { get; set; }

    public string DisplayName { get; set; }

    public string Password { get; set; }

    public string Host { get; set; }

    public int Port { get; set; }

    public bool Authenticate { get; set; }

    public string Status { get; set; }


    public virtual Company Company { get; set; }
}
