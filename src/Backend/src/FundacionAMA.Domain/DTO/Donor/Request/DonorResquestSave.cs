using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundacionAMA.Domain.DTO.Donor.Request
{
    public class DonorResquestSave
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
        public string status { get; set; }
    }
}
