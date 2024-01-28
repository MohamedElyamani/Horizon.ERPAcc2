using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Horizon.ERPAcc2.FiscalYearPeriods
{
    public class FiscalYearPeriod : FiscalYearPeriodBase
    {
        //<suite-custom-code-autogenerated>
        protected FiscalYearPeriod()
        {

        }

        public FiscalYearPeriod(Guid id, Guid fiscalYearId, string periodName, int companyId, DateTime startDate, DateTime endDate, int periodStatusId, bool isClosed, decimal totalDepit, decimal totalCredit, decimal closingBalance, decimal beginingInventory, decimal purchases, decimal endiningInventory, decimal cOGS, DateTime? closeDate = null)
            : base(id, fiscalYearId, periodName, companyId, startDate, endDate, periodStatusId, isClosed, totalDepit, totalCredit, closingBalance, beginingInventory, purchases, endiningInventory, cOGS, closeDate)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}