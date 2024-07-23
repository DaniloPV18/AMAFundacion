using FundacionAMA.Domain.DTO.Company.Filter;
using FundacionAMA.Domain.DTO.Company.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundacionAMA.Domain.Interfaces.Controller.Company
{
    public  interface ICompanyController : ICrudController<CompanyRequest, CompanyFilter, int>
    {

    }
}
