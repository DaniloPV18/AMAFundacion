using AutoMapper;

using FundacionAMA.Domain.DTO.Beneficiary.Dto;
using FundacionAMA.Domain.DTO.Beneficiary.Request;
using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Domain.Mapping
{
    public class BeneficiaryMapping : Profile
    {
        public BeneficiaryMapping()
        {
            CreateMap<Beneficiary, BeneficiaryDto>().IgnoreIfEmpty();
            CreateMap<Beneficiary, BeneficiaryDto>()
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
                .IgnoreIfEmpty();
            CreateMap<BeneficiaryRequest, Beneficiary>().IgnoreIfEmpty();
            CreateMap<BeneficiaryRequest, BeneficiaryDto>().IgnoreIfEmpty();
            CreateMap<BeneficiaryRequest, Person>()
                .IgnoreIfEmpty();
        }
    }
}
