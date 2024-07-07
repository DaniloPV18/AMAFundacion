using FundacionAMA.Domain.Shared.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundacionAMA.Domain.DTO.ActivityType.FilterDto

{
    public class ActivityTypeFilter : RequestPaginated

    {
        public string? Name { get; set; }
    }
}
