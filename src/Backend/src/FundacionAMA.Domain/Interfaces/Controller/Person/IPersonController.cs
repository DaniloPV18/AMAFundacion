using FundacionAMA.Domain.DTO.Person.FilterDto;
using FundacionAMA.Domain.DTO.Person.Request;

namespace FundacionAMA.Domain.Interfaces.Controller.Person
{
    public interface IPersonController : ICrudController<PersonRequest, PersonFilter, int>
    {
    }
}
