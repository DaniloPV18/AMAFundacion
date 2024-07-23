using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundacionAMA.Domain.DTO.ActivityType.Request
{
    public class ActivityTypeRequest
    {
        public int? CompanyId { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }
    }
}
