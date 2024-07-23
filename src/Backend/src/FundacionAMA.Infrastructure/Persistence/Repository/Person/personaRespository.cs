using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;

namespace FundacionAMA.Infrastructure.Persistence.Repository.PersonConfiguration
{
    public class PersonaRespository : BaseRepository<Person>, IPersonRepository
    {
        public PersonaRespository(AMADbContext context) : base(context)
        {
        }
    }
}
