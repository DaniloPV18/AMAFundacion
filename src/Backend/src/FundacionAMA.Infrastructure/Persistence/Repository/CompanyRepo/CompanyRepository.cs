using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundacionAMA.Infrastructure.Persistence.Repository.CompanyRepo
{
    internal class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AMADbContext context) : base(context) { }
    }
}
