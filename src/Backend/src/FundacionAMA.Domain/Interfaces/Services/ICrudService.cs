using FundacionAMA.Domain.Services;

namespace FundacionAMA.Domain.Interfaces.Services
{
    public interface ICrudServiceBase<TInput, TOutput, TFiler, TId> where TInput : class where TOutput : class where TFiler : class where TId : struct
    {
        Task<TOutput> GetById(TId id);
        Task<TOutput> GetByIdentification(string identificacion);

        Task<List<TOutput>> GetAll(TFiler filter);

        Task Create(TInput entity);

        Task Update(TId id, TInput entity);

        Task Delete(IOperationRequest<TId> id);
    }

    public interface ICrudService<TInput, TOutput, TFiler, TId> where TInput : class where TOutput : class where TFiler : class where TId : struct
    {
        Task<IOperationResult<TOutput>> GetById(TId id);

        Task<IOperationResult<TOutput>> GetByIdentification(string identificacion);

        Task<IOperationResultList<TOutput>> GetAll(TFiler filter);
        Task<IOperationResult<int>> GetCount();

        Task<IOperationResult> Create(TInput entity);

        Task<IOperationResult> Update(TId id, TInput entity);

        Task<IOperationResult> Delete(IOperationRequest<TId> id);
    }
}