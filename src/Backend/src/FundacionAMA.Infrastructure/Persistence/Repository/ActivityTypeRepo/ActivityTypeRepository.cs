using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;
using FundacionAMA.Domain.Shared.Interfaces.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundacionAMA.Infrastructure.Persistence.Repository.ActivityTypeRepo
{
    internal class ActivityTypeRepository: BaseRepository<ActivityType>, IActivityTypeRepository
    {
        public ActivityTypeRepository(AMADbContext context) : base(context) { }

        public Task<IOperationResult<int>> GetCount()
        {
            throw new NotImplementedException();
        }
    }
}
