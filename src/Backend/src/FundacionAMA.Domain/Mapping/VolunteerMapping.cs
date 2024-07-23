using AutoMapper;

using FundacionAMA.Domain.DTO.Volunteer.Dto;
using FundacionAMA.Domain.DTO.Volunteer.Request;
using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Domain.Mapping
{
    public class VolunteerMapping : Profile
    {
        public VolunteerMapping()
        {
            _ = CreateMap<Volunteer, VolunteerDto>()
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.Person.Id))
                .IgnoreIfEmpty();
            _ = CreateMap<Volunteer, VolunteerRequest>().IgnoreIfEmpty();
            _ = CreateMap<VolunteerDto, VolunteerRequest>().IgnoreIfEmpty();
            _ = CreateMap<VolunteerRequestSave, Volunteer>().IgnoreIfEmpty();
            _ = CreateMap<Volunteer, VolunteerDtoSave>()
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.Person.Id))
                .ForMember(dest => dest.identificacion, opt => opt.MapFrom(src => src.Person.Identification))
                .ForMember(dest => dest.namecomplete, opt => opt.MapFrom(src => src.Person.NameCompleted))
                .ForMember(dest => dest.phone, opt => opt.MapFrom(src => src.Person.Phone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Person.Email))
                .IgnoreIfEmpty();

        }
    }
}