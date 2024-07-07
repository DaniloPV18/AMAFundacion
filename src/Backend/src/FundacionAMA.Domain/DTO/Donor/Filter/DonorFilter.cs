using FundacionAMA.Domain.Shared.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundacionAMA.Domain.DTO.Donor.Filter
{
    public class DonorFilter : RequestPaginated
    {
        public int? PersonId { get; set; }
        public string? Identificacion { get; set; }
    }
}
