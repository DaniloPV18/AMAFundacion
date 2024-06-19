using AutoMapper;
using FundacionAMA.Domain.Entities;

namespace FundacionAMA.Application.DTO.SmtpConfigurationDTO;

public class SmtpConfigurationMappingProfile : Profile
{
    public SmtpConfigurationMappingProfile()
    {
        CreateMap<SmtpConfiguration, SmtpConfigurationDTO>().ReverseMap();
        CreateMap<SmtpConfigurationRequest, SmtpConfiguration>();
        CreateMap<SmtpConfigurationUpdate, SmtpConfiguration>();
    }
}
