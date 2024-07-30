using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Infrastructure.Persistence.Repository.PersonConfiguration
{
    public class PersonaRespository : BaseRepository<Person>, IPersonRepository
    {
        public PersonaRespository(AMADbContext context) : base(context)
        {
        }

        public Task<IOperationResult<int>> GetCount()
        {
            throw new NotImplementedException();
        }
    }
}
