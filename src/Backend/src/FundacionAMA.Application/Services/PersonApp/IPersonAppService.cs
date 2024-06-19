using FundacionAMA.Domain.DTO.Person;
using FundacionAMA.Domain.DTO.Person.FilterDto;
using FundacionAMA.Domain.DTO.Person.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Application.Services.PersonApp
{
    public interface IPersonAppService : ICrudService<IOperationRequest<PersonRequest>, PersonDto, PersonFilter, int>
    {

    }
}
