using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundacionAMA.Domain.DTO.Volunteer.Request
{
    public class VolunteerRequestSave
    {

        public int PersonId { get; set; }
        public string identificacion { get; set; }
        public string name { get; set; }
        public string secondname { get; set; }
        public string lastname { get; set; }
        public string secondlastname { get; set; }
        public string namecomplete { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string Gender { get; set; }

        public string Address { get; set; }

        public string Status { get; set; }

        public bool Availability { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ActivityTypeId { get; set; }
    }
}
