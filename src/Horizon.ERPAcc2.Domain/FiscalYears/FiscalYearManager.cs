using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Horizon.ERPAcc2.FiscalYears
{
    public abstract class FiscalYearManagerBase : DomainService
    {
        protected IFiscalYearRepository _fiscalYearRepository;

        public FiscalYearManagerBase(IFiscalYearRepository fiscalYearRepository)
        {
            _fiscalYearRepository = fiscalYearRepository;
        }

        public virtual async Task<FiscalYear> CreateAsync(
        int? fiscalYearStatusId, string fiscalYearName, DateTime startDate, DateTime endDate, int calanderYear, byte yearEndMonth, byte yearEndDay, bool isCurrent, bool isLocked, byte noOfPeriods, string periodInterval, DateTime? lockDate = null)
        {
            Check.NotNullOrWhiteSpace(fiscalYearName, nameof(fiscalYearName));
            Check.Length(fiscalYearName, nameof(fiscalYearName), FiscalYearConsts.FiscalYearNameMaxLength);
            Check.NotNull(startDate, nameof(startDate));
            Check.NotNull(endDate, nameof(endDate));
            Check.NotNullOrWhiteSpace(periodInterval, nameof(periodInterval));
            Check.Length(periodInterval, nameof(periodInterval), FiscalYearConsts.PeriodIntervalMaxLength);

            var fiscalYear = new FiscalYear(
             GuidGenerator.Create(),
             fiscalYearStatusId, fiscalYearName, startDate, endDate, calanderYear, yearEndMonth, yearEndDay, isCurrent, isLocked, noOfPeriods, periodInterval, lockDate
             );

            return await _fiscalYearRepository.InsertAsync(fiscalYear);
        }

        public virtual async Task<FiscalYear> UpdateAsync(
            Guid id,
            int? fiscalYearStatusId, string fiscalYearName, DateTime startDate, DateTime endDate, int calanderYear, byte yearEndMonth, byte yearEndDay, bool isCurrent, bool isLocked, byte noOfPeriods, string periodInterval, DateTime? lockDate = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(fiscalYearName, nameof(fiscalYearName));
            Check.Length(fiscalYearName, nameof(fiscalYearName), FiscalYearConsts.FiscalYearNameMaxLength);
            Check.NotNull(startDate, nameof(startDate));
            Check.NotNull(endDate, nameof(endDate));
            Check.NotNullOrWhiteSpace(periodInterval, nameof(periodInterval));
            Check.Length(periodInterval, nameof(periodInterval), FiscalYearConsts.PeriodIntervalMaxLength);

            var fiscalYear = await _fiscalYearRepository.GetAsync(id);

            fiscalYear.FiscalYearStatusId = fiscalYearStatusId;
            fiscalYear.FiscalYearName = fiscalYearName;
            fiscalYear.StartDate = startDate;
            fiscalYear.EndDate = endDate;
            fiscalYear.CalanderYear = calanderYear;
            fiscalYear.YearEndMonth = yearEndMonth;
            fiscalYear.YearEndDay = yearEndDay;
            fiscalYear.IsCurrent = isCurrent;
            fiscalYear.IsLocked = isLocked;
            fiscalYear.NoOfPeriods = noOfPeriods;
            fiscalYear.PeriodInterval = periodInterval;
            fiscalYear.LockDate = lockDate;

            fiscalYear.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _fiscalYearRepository.UpdateAsync(fiscalYear);
        }

    }
}