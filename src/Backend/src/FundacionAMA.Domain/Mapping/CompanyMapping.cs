using AutoMapper;
using FundacionAMA.Domain.DTO.Company.Dto;
using FundacionAMA.Domain.DTO.Company.Request;
using FundacionAMA.Domain.Shared.Extensions.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundacionAMA.Domain.Mapping
{
    public class CompanyMapping : Profile
    {
        public CompanyMapping() {

            CreateMap<CompanyRequest, Company>().IgnoreIfEmpty();
            CreateMap<Company, CompanyDto>().IgnoreIfEmpty();

        }
        
    }
}
