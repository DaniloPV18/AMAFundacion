using FundacionAMA.Domain.DTO.Donor.Request;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundacionAMA.Domain.DTO.Donor.Dto
{
    public class DonorDtoSave : DonorResquestSave    
    {
        public required int ID { get; set; }


    }
}
