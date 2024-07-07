using FundacionAMA.Domain.DTO.Donor.Dto;
using FundacionAMA.Domain.DTO.Donor.Filter;
using FundacionAMA.Domain.DTO.Donor.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundacionAMA.Domain.Interfaces.Services
{
    public interface IDonorService : ICrudService<IOperationRequest<DonorResquest>, DonorDto, DonorFilter,int>
    {
    }
}
