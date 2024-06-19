using FundacionAMA.Domain.DTO.Brigade.Dto;
using FundacionAMA.Domain.DTO.Brigade.FilterDto;
using FundacionAMA.Domain.DTO.Brigade.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

using Microsoft.Extensions.Logging;

namespace FundacionAMA.Application.Services.BrigadeApp
{
    internal class BrigadeAppService : IBrigadeAppService
    {
        private readonly IBrigadeService _brigadeService;
        private readonly ILogger<BrigadeAppService> _logger;

        public BrigadeAppService(IBrigadeService brigadeService, ILogger<BrigadeAppService> logger)
        {
            _brigadeService = brigadeService;
            _logger = logger;
        }

        public async Task<IOperationResult> Create(IOperationRequest<BrigadeRequest> entity)
        {
            return await _brigadeService.Create(entity);

        }

        public async Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            return await _brigadeService.Delete(id);
        }

        public async Task<IOperationResultList<BrigadeDto>> GetAll(BrigadeFilter filter)
        {
            return await _brigadeService.GetAll(filter);
        }

        public async Task<IOperationResult<BrigadeDto>> GetById(int id)
        {
            return await _brigadeService.GetById(id);
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<BrigadeRequest> entity)
        {
            return await _brigadeService.Update(id, entity);
        }
    }
}
