using Microsoft.AspNetCore.Mvc;

namespace FundacionAMA.Domain.Interfaces.Controller
{
    public interface ICrudController<TInputDto, TQueryFrom, TId> where TInputDto : class where TQueryFrom : class where TId : struct
    {
        Task<IActionResult> GetById(TId id);
        Task<IActionResult> GetAll(TQueryFrom filter);
        Task<IActionResult> Create(TInputDto entity);
        Task<IActionResult> Update(TId id, TInputDto entity);
        Task<IActionResult> Delete(TId id);
    }
}
