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
    public abstract class FiscalYearPeriodBase : Entity<Guid>
    {
        public virtual Guid FiscalYearId { get; set; }

        [NotNull]
        public virtual string PeriodName { get; set; }

        public virtual int CompanyId { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        public virtual int PeriodStatusId { get; set; }

        public virtual bool IsClosed { get; set; }

        public virtual DateTime? CloseDate { get; set; }

        public virtual decimal TotalDepit { get; set; }

        public virtual decimal TotalCredit { get; set; }

        public virtual decimal ClosingBalance { get; set; }

        public virtual decimal BeginingInventory { get; set; }

        public virtual decimal Purchases { get; set; }

        public virtual decimal EndiningInventory { get; set; }

        public virtual decimal COGS { get; set; }

        protected FiscalYearPeriodBase()
        {

        }

        public FiscalYearPeriodBase(Guid id, Guid fiscalYearId, string periodName, int companyId, DateTime startDate, DateTime endDate, int periodStatusId, bool isClosed, decimal totalDepit, decimal totalCredit, decimal closingBalance, decimal beginingInventory, decimal purchases, decimal endiningInventory, decimal cOGS, DateTime? closeDate = null)
        {

            Id = id;
            Check.NotNull(periodName, nameof(periodName));
            Check.Length(periodName, nameof(periodName), FiscalYearPeriodConsts.PeriodNameMaxLength, 0);
            FiscalYearId = fiscalYearId;
            PeriodName = periodName;
            CompanyId = companyId;
            StartDate = startDate;
            EndDate = endDate;
            PeriodStatusId = periodStatusId;
            IsClosed = isClosed;
            TotalDepit = totalDepit;
            TotalCredit = totalCredit;
            ClosingBalance = closingBalance;
            BeginingInventory = beginingInventory;
            Purchases = purchases;
            EndiningInventory = endiningInventory;
            COGS = cOGS;
            CloseDate = closeDate;
        }

    }
}