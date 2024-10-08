﻿namespace FundacionAMA.Domain.Interfaces.Repositories
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<IOperationResult<int>> GetCount();
    }
}
