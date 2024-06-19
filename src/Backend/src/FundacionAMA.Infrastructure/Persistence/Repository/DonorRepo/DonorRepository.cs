using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundacionAMA.Infrastructure.Persistence.Repository.DonorRepo
{
    internal  class DonorRepository : BaseRepository<Donor>, IDonorRepository
    {
        public DonorRepository(AMADbContext context) : base(context)
        {
        }
    }
}
