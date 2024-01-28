using Horizon.ERPAcc2.FiscalYearStatuses;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Horizon.ERPAcc2.FiscalYearPeriods;

using Volo.Abp;

namespace Horizon.ERPAcc2.FiscalYears
{
    public abstract class FiscalYearBase : AuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string FiscalYearName { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        public virtual DateTime? LockDate { get; set; }

        public virtual int CalanderYear { get; set; }

        public virtual int YearEndMonth { get; set; }

        public virtual int YearEndDay { get; set; }

        public virtual bool IsCurrent { get; set; }

        public virtual bool IsLocked { get; set; }

        public virtual int NoOfPeriods { get; set; }

        [NotNull]
        public virtual string PeriodInterval { get; set; }
        public int? FiscalYearStatusId { get; set; }
        public ICollection<FiscalYearPeriod> FiscalYearPeriods { get; private set; }

        protected FiscalYearBase()
        {

        }

        public FiscalYearBase(Guid id, int? fiscalYearStatusId, string fiscalYearName, DateTime startDate, DateTime endDate, int calanderYear, byte yearEndMonth, byte yearEndDay, bool isCurrent, bool isLocked, byte noOfPeriods, string periodInterval, DateTime? lockDate = null)
        {

            Id = id;
            Check.NotNull(fiscalYearName, nameof(fiscalYearName));
            Check.Length(fiscalYearName, nameof(fiscalYearName), FiscalYearConsts.FiscalYearNameMaxLength, 0);
            Check.NotNull(periodInterval, nameof(periodInterval));
            Check.Length(periodInterval, nameof(periodInterval), FiscalYearConsts.PeriodIntervalMaxLength, 0);
            FiscalYearName = fiscalYearName;
            StartDate = startDate;
            EndDate = endDate;
            CalanderYear = calanderYear;
            YearEndMonth = yearEndMonth;
            YearEndDay = yearEndDay;
            IsCurrent = isCurrent;
            IsLocked = isLocked;
            NoOfPeriods = noOfPeriods;
            PeriodInterval = periodInterval;
            LockDate = lockDate;
            FiscalYearStatusId = fiscalYearStatusId;
            FiscalYearPeriods = new Collection<FiscalYearPeriod>();
        }

    }
}