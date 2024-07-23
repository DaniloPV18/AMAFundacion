using AutoMapper;

using FundacionAMA.Domain.DTO.Catalogo.Dto;
using FundacionAMA.Domain.DTO.Catalogo.Request;
using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Domain.Mapping
{
    public class TypeIdentificationMapping : Profile
    {
        public TypeIdentificationMapping()
        {
            _ = CreateMap<IdentificationType, TypeIdentificationDto>().IgnoreIfEmpty();
            _ = CreateMap<IdentificationType, TypeIdentificationRequest>().IgnoreIfEmpty();
            _ = CreateMap<TypeIdentificationRequest, TypeIdentificationDto>().IgnoreIfEmpty();

        }
    }
}
