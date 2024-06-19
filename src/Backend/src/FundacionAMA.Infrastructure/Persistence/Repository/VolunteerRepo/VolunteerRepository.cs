using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;

namespace FundacionAMA.Infrastructure.Persistence.Repository.VolunteerRepo
{
    internal class VolunteerRepository : BaseRepository<Volunteer>, IVolunteerRepository
    {
        public VolunteerRepository(AMADbContext context) : base(context)
        {
        }
    }
}