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
    public abstract class FiscalYearStatusBase : AuditedAggregateRoot<int>
    {
        [NotNull]
        public virtual string FiscalYearStatusTitle { get; set; }

        protected FiscalYearStatusBase()
        {

        }

        public FiscalYearStatusBase(string fiscalYearStatusTitle)
        {

            Check.NotNull(fiscalYearStatusTitle, nameof(fiscalYearStatusTitle));
            Check.Length(fiscalYearStatusTitle, nameof(fiscalYearStatusTitle), FiscalYearStatusConsts.FiscalYearStatusTitleMaxLength, 0);
            FiscalYearStatusTitle = fiscalYearStatusTitle;
        }

    }
}