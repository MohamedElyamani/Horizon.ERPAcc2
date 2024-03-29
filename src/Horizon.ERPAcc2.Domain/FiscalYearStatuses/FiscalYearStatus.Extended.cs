using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Horizon.ERPAcc2.FiscalYearStatuses
{
    public class FiscalYearStatus : FiscalYearStatusBase
    {
        //<suite-custom-code-autogenerated>
        protected FiscalYearStatus()
        {

        }

        public FiscalYearStatus(string fiscalYearStatusTitle)
            : base(fiscalYearStatusTitle)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}