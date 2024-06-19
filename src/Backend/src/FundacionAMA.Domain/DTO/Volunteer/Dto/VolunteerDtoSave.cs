using FundacionAMA.Domain.DTO.Volunteer.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundacionAMA.Domain.DTO.Volunteer.Dto
{
    public class VolunteerDtoSave : VolunteerRequestSave
    {
        public required int Id { get; set; }
    }
}
