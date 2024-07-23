using AutoMapper;

using FundacionAMA.Domain.DTO.Person;
using FundacionAMA.Domain.DTO.Person.Request;
using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Domain.Mapping
{
    public class PersonMapping : Profile
    {
        public PersonMapping()
        {
            CreateMap<PersonDto, Person>().IgnoreIfEmpty();

            CreateMap<PersonRequestHeader, PersonRequestHeader>().IgnoreIfEmpty();
            CreateMap<PersonRequestHeader, Person>().IgnoreIfEmpty();
            CreateMap<PersonRequestHeader, PersonDto>().IgnoreIfEmpty();
            CreateMap<PersonRequest, Beneficiary>()
                .IgnoreIfEmpty();
        }
    }
}
