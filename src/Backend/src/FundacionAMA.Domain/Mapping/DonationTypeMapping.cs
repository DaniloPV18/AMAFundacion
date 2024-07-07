using AutoMapper;

using FundacionAMA.Domain.DTO.Catalogo.Dto;
using FundacionAMA.Domain.DTO.Catalogo.Request;
using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Domain.Mapping
{
    public class DonationTypeMapping : Profile
    {
        public DonationTypeMapping()
        {
            _ = CreateMap<DonationType, DonationTypeDto>().IgnoreIfEmpty();
            _ = CreateMap<DonationType, DonationTypeRequest>().IgnoreIfEmpty();
            _ = CreateMap<DonationTypeRequest, DonationTypeDto>().IgnoreIfEmpty();
        }
    }
}
