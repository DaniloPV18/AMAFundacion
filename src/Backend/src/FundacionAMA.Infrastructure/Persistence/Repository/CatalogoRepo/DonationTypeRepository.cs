using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;

namespace FundacionAMA.Infrastructure.Persistence.Repository.CatalogoRepo
{
    internal class DonationTypeRepository : BaseRepository<DonationType>, IDonationTypeRepository
    {
        public DonationTypeRepository(AMADbContext context) : base(context)
        {
        }

    }
}
