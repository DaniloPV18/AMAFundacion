using AutoMapper;

using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Domain.Mapping
{
    public class BrigadeMapping : Profile
    {
        public BrigadeMapping()
        {
            CreateMap<BrigadeRequest, Brigade>().IgnoreIfEmpty();
            CreateMap<Brigade, BrigadeDto>()
                .ForMember(dest => dest.IdentificationPerson, opt => opt.MapFrom(src => src.Person.Identification))
                .ForMember(dest => dest.NameCompletedPerson, opt => opt.MapFrom(src => src.Person.NameCompleted))
                .IgnoreIfEmpty();
            CreateMap<BrigadeRequest, BrigadeDto>().IgnoreIfEmpty();
        }
    }
}
