using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;

namespace FundacionAMA.Infrastructure.Persistence.Repository.BrigadeRepo
{
    public class BrigadeRepository : BaseRepository<Brigade>, IBrigadeRepository
    {

        public BrigadeRepository(AMADbContext context) : base(context)
        {
        }
    }
}
