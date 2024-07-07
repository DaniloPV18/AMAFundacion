using FundacionAMA.Application.DTO.UserDTO;

namespace FundacionAMA.Application.Services.UserApp;

public interface IUserAppService
{
    UserDTO GetById(int id);
    IEnumerable<UserDTO> GetAll(UserQuery filter);
    UserDTO Create(UserRequest user);
    void Update(int id, UserUpdate user);
}
