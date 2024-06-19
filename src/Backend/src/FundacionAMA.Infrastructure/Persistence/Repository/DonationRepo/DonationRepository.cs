using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;

namespace FundacionAMA.Infrastructure.Persistence.Repository.DonationRepo
{
    internal class DonationRepository : BaseRepository<Donation>, IDonationRepository
    {
        public DonationRepository(AMADbContext context) : base(context)
        {
        }
    }
}
