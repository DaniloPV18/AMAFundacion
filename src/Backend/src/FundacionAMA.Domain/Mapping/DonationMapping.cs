using AutoMapper;

using FundacionAMA.Domain.DTO.Donation.Dto;
using FundacionAMA.Domain.DTO.Donation.Request;
using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Domain.Mapping
{
    public class DonationMapping : Profile
    {
        public DonationMapping()
        {
            _ = CreateMap<Donation, DonationDto>()
                .ForMember(d => d.DonationType, opt => opt.MapFrom(s => s.DonationType.Name))
                .ForMember(d => d.NameCompletedPerson, opt => opt.MapFrom(s => s.Person.Person.NameCompleted))
                .ForMember(d => d.IdentificationPerson, opt => opt.MapFrom(s => s.Person.Person.Identification))
                .ForMember(d => d.NameBrigade, opt => opt.MapFrom(s => s.Brigade.Name))
                .ForMember(d => d.PersonId, opt => opt.MapFrom(s => s.PersonId))
                .IgnoreIfEmpty();
            _ = CreateMap<Donation, DonationRequest>().IgnoreIfEmpty();
            _ = CreateMap<Donation, DonationRequest>().IgnoreIfEmpty();
            _ = CreateMap<DonationType, DonationDto>().IgnoreIfEmpty();

        }
    }
}
