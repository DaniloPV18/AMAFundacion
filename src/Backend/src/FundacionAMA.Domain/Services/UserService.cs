using FundacionAMA.Domain.Shared.Interfaces;

using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace FundacionAMA.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    private readonly IClaimsService _claimsService;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository usuarioRepository, IAuthService authService, IClaimsService claimsService, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _userRepository = usuarioRepository;
        _authService = authService;
        _claimsService = claimsService;
    }

    public User? GetById(int userId)
        =>
        _userRepository.GetById(userId);

    public IEnumerable<User> GetAll(Expression<Func<User, bool>>? filter = null)
        =>
        _userRepository.GetAll(filter);

    public void Create(User user)
    {
        user.Identification = user.Identification.ToLower();
        if (_userRepository.GetAll(a => a.Identification == user.Identification).FirstOrDefault() is not null)
            throw new Exception("Ya existe un usuario con esa identificación");
        var result = _authService.CreateHash(user.Password);
        user.Password = result.Hash;
        user.Salt = result.Salt;

        if (user is IAudit)
        {
            user.CreatedAt = DateTime.Now;
            user.CreatedBy = _claimsService.UserId;
        }

        _userRepository.Insert(user); 
            
        _unitOfWork.SaveChanges();
    }

    public void Update(User user)
    {
        

        if (user is IAudit && _claimsService.Autenticated)
        {
            user.UpdatedAt = DateTime.Now;
            user.UpdatedBy = _claimsService.UserId;
        }
        _userRepository.Update(user);
        _unitOfWork.SaveChanges();
    }

    public void UpdatePassword(User user)
    {
        var result = _authService.CreateHash(user.Password);
        user.Password = result.Hash;
        user.Salt = result.Salt;
        user.TempCode = null;
        user.TempCodeCreateAt = null;

        if (user is IAudit && _claimsService.Autenticated)
        {
            user.CreatedAt = DateTime.Now;
            user.CreatedBy = _claimsService.UserId;
        }

        _userRepository.Update(user);
    }


}
