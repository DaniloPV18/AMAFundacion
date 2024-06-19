using FundacionAMA.Application.DTO.AuthDTO;
using FundacionAMA.Domain.DTO.EmailServiceProfile;
using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;
using FundacionAMA.Domain.Interfaces.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FundacionAMA.Application.Services.AuthApp;

public class AuthAppService : IAuthAppService
{

    private readonly IConfiguration _configuration;
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISMTPService _smtpService;
    private readonly ISmtpConfigurationService _smtpConfigurationService;


    public AuthAppService(IConfiguration configuration, IAuthService authService, IUserService userService, IUnitOfWork unitOfWork, ISMTPService smtpService, ISmtpConfigurationService smtpConfigurationService)
    {
        _configuration = configuration;
        _authService = authService;
        _userService = userService;
        _unitOfWork = unitOfWork;
        _smtpService = smtpService;
        _smtpConfigurationService = smtpConfigurationService;
    }

    public AuthDTO Login(AuthRequest login)
    {
        (bool IsValid, User? User) _validUser = IsValidUser(login.User);

        if (_validUser.IsValid && _validUser.User != null)
        {
            if (_authService.Autenticate(_validUser.User.Id, login.Password))
            {
                return new AuthDTO(GenerateJwtToken(_validUser.User), DateTimeOffset.Now);
            }
        }

        return new AuthDTO();
    }

    private (bool IsValid, User? User) IsValidUser(string identification)
    {
        User? _user = _userService.GetAll(a => a.Identification == identification && a.Status == "A").FirstOrDefault();
        return (IsValid: _user != null, User: _user);
    }

    private string GenerateJwtToken(User user)
    {
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(24),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!)),
                SecurityAlgorithms.HmacSha512Signature)
        };

        JwtSecurityTokenHandler tokenHandler = new();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<ResetPasswordDTO> SendCodeToResetPassword(SendCodeToResetPasswordRequest login)
    {
        (bool IsValid, User? User) _validUser = IsValidUser(login.Identification);
        if (_validUser.IsValid)
        {
            if (_validUser.User != null)
            {
                string _code = GenerateUniqueCode(_validUser.User.Id);
                string filePath = "../FundacionAMA.Application/Report/ResetPasswordMail.html";
                string htmlContent = File.ReadAllText(filePath).Replace("[codigo]", _code);

                EmailRequest _emailRequest = new()
                {
                    ProfileId = 1,
                    IsHTML = true,
                    Body = htmlContent,
                    Subject = "Reset Password",
                    To = new string[] { _validUser.User.Email }
                };

                (bool IsSuccessful, string Message) = await _smtpService.SendEmailAsync(_emailRequest, _smtpConfigurationService.GetByProfileId(1));
                return IsSuccessful
                    ? new ResetPasswordDTO(true, $"Código enviado al email")
                    : new ResetPasswordDTO(false, $"Error al enviar el código: {Message}");


            }

        }

        return new ResetPasswordDTO(false, "No se encontró el usuario");
    }

    public ResetPasswordDTO ResetPassword(ResetPasswordRequest login)
    {
        (bool IsValid, User? User) _validUser = IsValidUser(login.Identification);
        if (_validUser.IsValid)
        {
            if (_validUser.User != null)
            {
                if (CodeIsValid(_validUser.User.Id, login.Code))
                {

                    User? _user = _userService.GetById(_validUser.User.Id);
                    if (_user != null)
                    {
                        _user.Password = login.Password;
                        _userService.UpdatePassword(_user);
                        _unitOfWork.SaveChanges();
                        return new ResetPasswordDTO(true, "Clave actualizada");
                    }
                }
                else
                {
                    return new ResetPasswordDTO(false, "El código es inválido");
                }
            }

        }

        return new ResetPasswordDTO(false, "No se encontró el usuario");
    }


    private string GenerateUniqueCode(int userId, int length = 6)
    {
        const string allowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        byte[] randomBytes = new byte[length];

        using (RandomNumberGenerator cryptoProvider = RandomNumberGenerator.Create())
        {
            cryptoProvider.GetBytes(randomBytes);
        }

        char[] characters = new char[length];
        int allowedCharactersLength = allowedCharacters.Length;

        for (int i = 0; i < length; i++)
        {
            characters[i] = allowedCharacters[randomBytes[i] % allowedCharactersLength];
        }

        string code = new(characters);

        if (CodeIsUnique(code))
        {
            SaveCodeInDatabase(userId, code);
            return code;
        }

        return GenerateUniqueCode(userId, length);
    }

    private bool CodeIsUnique(string code)
    {
        var time = DateTime.Now.AddMinutes(-5);
        return _userService.GetAll(a => a.TempCode == code && a.TempCodeCreateAt >= time ).FirstOrDefault() == null;
    }

    private bool CodeIsValid(int userId, string code)
    {
        var time = DateTime.Now.AddMinutes(-5);
        return _userService.GetAll(a => a.Id == userId && a.TempCode == code && a.TempCodeCreateAt >= time).FirstOrDefault() != null;
    }

    private void SaveCodeInDatabase(int userId, string code)
    {
        User? _user = _userService.GetById(userId);
        if (_user != null)
        {
            _user.TempCode = code;
            _user.TempCodeCreateAt = DateTime.Now;
            _userService.Update(_user);
            _unitOfWork.SaveChanges();
        }
        else
        {
            throw new Exception("No se encontró el usuario");
        }
    }

}
