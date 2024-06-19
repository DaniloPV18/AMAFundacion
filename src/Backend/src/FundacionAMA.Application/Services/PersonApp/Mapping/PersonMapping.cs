using AutoMapper;

using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Application.Services.PersonApp.Mapping
{
    public class PersonMapping : Profile
    {
        public PersonMapping()
        {
            CreateMap<Domain.Entities.Person, Domain.DTO.Person.PersonDto>()
                .ForMember(dest => dest.Donor, opt => opt.MapFrom(src => src.Donor))
                .ForMember(dest => dest.Volunteer, opt => opt.MapFrom(src => src.Volunteer))
                .IgnoreIfEmpty();

            CreateMap<Domain.DTO.Person.Request.PersonRequest, Domain.Entities.Person>()
                .ForMember(dest => dest.Donor, opt => opt.MapFrom(src => src.Donor))
                .ForMember(dest => dest.Volunteer, opt => opt.MapFrom(src => src.Volunteer))
                .IgnoreIfEmpty();
            
            CreateMap<Domain.DTO.Person.FilterDto.PersonFilter, Domain.Entities.Person>().IgnoreIfEmpty();
            
            CreateMap<Domain.Entities.Person, Domain.DTO.Person.FilterDto.PersonFilter>().IgnoreIfEmpty();
        }
    }
}
