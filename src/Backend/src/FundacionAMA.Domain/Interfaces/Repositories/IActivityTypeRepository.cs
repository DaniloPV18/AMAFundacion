

namespace FundacionAMA.Domain.Interfaces.Repositories
{
    public interface IActivityTypeRepository : IBaseRepository<ActivityType>
    {
        Task<IOperationResult<int>> GetCount();
    }
}
