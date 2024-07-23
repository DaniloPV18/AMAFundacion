using FundacionAMA.Domain.DTO.ActivityType.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundacionAMA.Domain.DTO.ActivityType.Dto
{
    public class ActivityTypeDto: ActivityTypeRequest
    {
        public required int Id { get; set; }
    }
}
