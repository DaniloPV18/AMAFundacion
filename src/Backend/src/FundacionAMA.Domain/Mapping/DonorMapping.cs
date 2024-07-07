using FundacionAMA.Domain.DTO.Donor.Dto;
using FundacionAMA.Domain.DTO.Donor.Request;

using AutoMapper;
using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Domain.Mapping
{
    public class DonorMapping: Profile
    {

        public DonorMapping() 
        {
            CreateMap<DonorResquest, Donor>().IgnoreIfEmpty();
            CreateMap<DonorResquestSave, Donor>().IgnoreIfEmpty();
            CreateMap<Donor, DonorDto>()
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.Person.Id))
                .ForMember(dest => dest.Identificacion, opt => opt.MapFrom(src => src.Person.Identification))
                .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => src.Person.NameCompleted))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Person.Phone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Person.Email))
                .IgnoreIfEmpty();

        }

    }
}
