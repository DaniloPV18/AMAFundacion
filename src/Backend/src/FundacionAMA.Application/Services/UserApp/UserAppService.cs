using AutoMapper;
using FundacionAMA.Application.DTO.UserDTO;
using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Services;

namespace FundacionAMA.Application.Services.UserApp;

public class UserAppService : IUserAppService
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserAppService(IUserService userService, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _userService = userService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public UserDTO GetById(int userId)
        =>
        _mapper.Map<UserDTO>(_userService.GetById(userId));


    public IEnumerable<UserDTO> GetAll(UserQuery filter)
    {
       return _mapper.Map<IEnumerable<UserDTO>>(_userService.GetAll(a =>
           (a.Identification.Contains(filter.Identification) || string.IsNullOrEmpty(filter.Identification)) &&
           (a.Name.Contains(filter.Status) || string.IsNullOrEmpty(filter.Status))
           ).ToList());
    }

    public UserDTO Create(UserRequest newUserDTO)
    {
        var _user = _mapper.Map<User>(newUserDTO);

        _userService.Create(_user);
        _unitOfWork.SaveChanges();
        return _mapper.Map<UserDTO>(_user);
    }

    public void Update(int userId, UserUpdate updatedUserDTO)
    {
        var existingUser = _userService.GetById(userId);

        if (existingUser != null)
        {
            if(string.IsNullOrEmpty(updatedUserDTO.Password))
                updatedUserDTO.Password= existingUser.Password;
            _mapper.Map(updatedUserDTO, existingUser);

            _userService.Update(existingUser);
            
            //if(!string.IsNullOrEmpty( updatedUserDTO.Password))
            //{
            //    existingUser.Password=updatedUserDTO.Password;
            //    _userService.UpdatePassword(existingUser);
            //}

            _unitOfWork.SaveChanges();
        }
    }


}


