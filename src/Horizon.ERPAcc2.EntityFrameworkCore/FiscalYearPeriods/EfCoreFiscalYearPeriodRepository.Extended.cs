using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Horizon.ERPAcc2.EntityFrameworkCore;

namespace Horizon.ERPAcc2.FiscalYearPeriods
{
    public class EfCoreFiscalYearPeriodRepository : EfCoreFiscalYearPeriodRepositoryBase, IFiscalYearPeriodRepository
    {
        public EfCoreFiscalYearPeriodRepository(IDbContextProvider<ERPAcc2DbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}