using AutoMapper;
using FundacionAMA.Application.DTO.SmtpConfigurationDTO;
using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;
using FundacionAMA.Domain.Interfaces.Services;

namespace FundacionAMA.Application.Services.SmtpConfigurationApp;

public class SmtpConfigurationAppService : ISmtpConfigurationAppService
{
    private readonly ISmtpConfigurationService _smtpService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public SmtpConfigurationAppService(ISmtpConfigurationService userService, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _smtpService = userService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public SmtpConfigurationDTO GetById(int id)
        =>
        _mapper.Map<SmtpConfigurationDTO>(_smtpService.GetById(id));


    public IEnumerable<SmtpConfigurationDTO> GetAll(SmtpConfigurationQuery filter)
        =>
        _mapper.Map<IEnumerable<SmtpConfigurationDTO>>(_smtpService.GetAll());


    public SmtpConfigurationDTO Create(SmtpConfigurationRequest newObj)
    {
        var _user = _mapper.Map<SmtpConfiguration>(newObj);

        _smtpService.Create(_user);
        _unitOfWork.SaveChanges();
        return _mapper.Map<SmtpConfigurationDTO>(_user);
    }

    public void Update(int id, SmtpConfigurationUpdate updatedObj)
    {
        var existingUser = _smtpService.GetById(id);
        ;
        if (existingUser != null)
        {
            _mapper.Map(updatedObj, existingUser);

            _smtpService.Update(existingUser);
            _unitOfWork.SaveChanges();
        }
    }

    public void UpdatePassword(int id, string password)
    {

        var existingObj = _smtpService.GetById(id);

        if (existingObj != null)
        {
            existingObj.Password = password;

            _smtpService.UpdatePassword(existingObj);
            _unitOfWork.SaveChanges();
        }
    }

}


