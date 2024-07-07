using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;

namespace FundacionAMA.Infrastructure.Persistence.Repository.CatalogoRepo
{
    internal class TypeIdentificationRepository : BaseRepository<IdentificationType>, ITypeIdentificationRepository
    {
        public TypeIdentificationRepository(AMADbContext context) : base(context)
        {
        }
    }
}
