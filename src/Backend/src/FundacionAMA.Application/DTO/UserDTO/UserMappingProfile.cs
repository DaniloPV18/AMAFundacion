using AutoMapper;
using FundacionAMA.Domain.Entities;

namespace FundacionAMA.Application.DTO.UserDTO;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<UserRequest, User>()
            .BeforeMap((src, dest) => dest.Status = "A");

        CreateMap<UserUpdate, User>();
    }
}
