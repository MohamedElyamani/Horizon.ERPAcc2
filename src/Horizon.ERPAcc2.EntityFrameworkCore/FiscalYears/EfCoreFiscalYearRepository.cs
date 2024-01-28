using Horizon.ERPAcc2.FiscalYearStatuses;
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

namespace Horizon.ERPAcc2.FiscalYears
{
    public abstract class EfCoreFiscalYearRepositoryBase : EfCoreRepository<ERPAcc2DbContext, FiscalYear, Guid>
    {
        public EfCoreFiscalYearRepositoryBase(IDbContextProvider<ERPAcc2DbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<FiscalYearWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();

            return (await GetDbSetAsync()).Where(b => b.Id == id)
                .Select(fiscalYear => new FiscalYearWithNavigationProperties
                {
                    FiscalYear = fiscalYear,
                    FiscalYearStatus = dbContext.Set<FiscalYearStatus>().FirstOrDefault(c => c.Id == fiscalYear.FiscalYearStatusId)
                }).FirstOrDefault();
        }

        public virtual async Task<List<FiscalYearWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? fiscalYearName = null,
            DateTime? startDateMin = null,
            DateTime? startDateMax = null,
            DateTime? endDateMin = null,
            DateTime? endDateMax = null,
            DateTime? lockDateMin = null,
            DateTime? lockDateMax = null,
            int? calanderYearMin = null,
            int? calanderYearMax = null,
            byte? yearEndMonthMin = null,
            byte? yearEndMonthMax = null,
            byte? yearEndDayMin = null,
            byte? yearEndDayMax = null,
            bool? isCurrent = null,
            bool? isLocked = null,
            byte? noOfPeriodsMin = null,
            byte? noOfPeriodsMax = null,
            string? periodInterval = null,
            int? fiscalYearStatusId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, fiscalYearName, startDateMin, startDateMax, endDateMin, endDateMax, lockDateMin, lockDateMax, calanderYearMin, calanderYearMax, yearEndMonthMin, yearEndMonthMax, yearEndDayMin, yearEndDayMax, isCurrent, isLocked, noOfPeriodsMin, noOfPeriodsMax, periodInterval, fiscalYearStatusId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? FiscalYearConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<FiscalYearWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from fiscalYear in (await GetDbSetAsync())
                   join fiscalYearStatus in (await GetDbContextAsync()).Set<FiscalYearStatus>() on fiscalYear.FiscalYearStatusId equals fiscalYearStatus.Id into fiscalYearStatuses
                   from fiscalYearStatus in fiscalYearStatuses.DefaultIfEmpty()
                   select new FiscalYearWithNavigationProperties
                   {
                       FiscalYear = fiscalYear,
                       FiscalYearStatus = fiscalYearStatus
                   };
        }

        protected virtual IQueryable<FiscalYearWithNavigationProperties> ApplyFilter(
            IQueryable<FiscalYearWithNavigationProperties> query,
            string? filterText,
            string? fiscalYearName = null,
            DateTime? startDateMin = null,
            DateTime? startDateMax = null,
            DateTime? endDateMin = null,
            DateTime? endDateMax = null,
            DateTime? lockDateMin = null,
            DateTime? lockDateMax = null,
            int? calanderYearMin = null,
            int? calanderYearMax = null,
            byte? yearEndMonthMin = null,
            byte? yearEndMonthMax = null,
            byte? yearEndDayMin = null,
            byte? yearEndDayMax = null,
            bool? isCurrent = null,
            bool? isLocked = null,
            byte? noOfPeriodsMin = null,
            byte? noOfPeriodsMax = null,
            string? periodInterval = null,
            int? fiscalYearStatusId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.FiscalYear.FiscalYearName!.Contains(filterText!) || e.FiscalYear.PeriodInterval!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(fiscalYearName), e => e.FiscalYear.FiscalYearName.Contains(fiscalYearName))
                    .WhereIf(startDateMin.HasValue, e => e.FiscalYear.StartDate >= startDateMin!.Value)
                    .WhereIf(startDateMax.HasValue, e => e.FiscalYear.StartDate <= startDateMax!.Value)
                    .WhereIf(endDateMin.HasValue, e => e.FiscalYear.EndDate >= endDateMin!.Value)
                    .WhereIf(endDateMax.HasValue, e => e.FiscalYear.EndDate <= endDateMax!.Value)
                    .WhereIf(lockDateMin.HasValue, e => e.FiscalYear.LockDate >= lockDateMin!.Value)
                    .WhereIf(lockDateMax.HasValue, e => e.FiscalYear.LockDate <= lockDateMax!.Value)
                    .WhereIf(calanderYearMin.HasValue, e => e.FiscalYear.CalanderYear >= calanderYearMin!.Value)
                    .WhereIf(calanderYearMax.HasValue, e => e.FiscalYear.CalanderYear <= calanderYearMax!.Value)

                    .WhereIf(isCurrent.HasValue, e => e.FiscalYear.IsCurrent == isCurrent)
                    .WhereIf(isLocked.HasValue, e => e.FiscalYear.IsLocked == isLocked)

                    .WhereIf(!string.IsNullOrWhiteSpace(periodInterval), e => e.FiscalYear.PeriodInterval.Contains(periodInterval))
                    .WhereIf(fiscalYearStatusId != null, e => e.FiscalYearStatus != null && e.FiscalYearStatus.Id == fiscalYearStatusId);
        }

        public virtual async Task<List<FiscalYear>> GetListAsync(
            string? filterText = null,
            string? fiscalYearName = null,
            DateTime? startDateMin = null,
            DateTime? startDateMax = null,
            DateTime? endDateMin = null,
            DateTime? endDateMax = null,
            DateTime? lockDateMin = null,
            DateTime? lockDateMax = null,
            int? calanderYearMin = null,
            int? calanderYearMax = null,
            byte? yearEndMonthMin = null,
            byte? yearEndMonthMax = null,
            byte? yearEndDayMin = null,
            byte? yearEndDayMax = null,
            bool? isCurrent = null,
            bool? isLocked = null,
            byte? noOfPeriodsMin = null,
            byte? noOfPeriodsMax = null,
            string? periodInterval = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, fiscalYearName, startDateMin, startDateMax, endDateMin, endDateMax, lockDateMin, lockDateMax, calanderYearMin, calanderYearMax, yearEndMonthMin, yearEndMonthMax, yearEndDayMin, yearEndDayMax, isCurrent, isLocked, noOfPeriodsMin, noOfPeriodsMax, periodInterval);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? FiscalYearConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? fiscalYearName = null,
            DateTime? startDateMin = null,
            DateTime? startDateMax = null,
            DateTime? endDateMin = null,
            DateTime? endDateMax = null,
            DateTime? lockDateMin = null,
            DateTime? lockDateMax = null,
            int? calanderYearMin = null,
            int? calanderYearMax = null,
            byte? yearEndMonthMin = null,
            byte? yearEndMonthMax = null,
            byte? yearEndDayMin = null,
            byte? yearEndDayMax = null,
            bool? isCurrent = null,
            bool? isLocked = null,
            byte? noOfPeriodsMin = null,
            byte? noOfPeriodsMax = null,
            string? periodInterval = null,
            int? fiscalYearStatusId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, fiscalYearName, startDateMin, startDateMax, endDateMin, endDateMax, lockDateMin, lockDateMax, calanderYearMin, calanderYearMax, yearEndMonthMin, yearEndMonthMax, yearEndDayMin, yearEndDayMax, isCurrent, isLocked, noOfPeriodsMin, noOfPeriodsMax, periodInterval, fiscalYearStatusId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<FiscalYear> ApplyFilter(
            IQueryable<FiscalYear> query,
            string? filterText = null,
            string? fiscalYearName = null,
            DateTime? startDateMin = null,
            DateTime? startDateMax = null,
            DateTime? endDateMin = null,
            DateTime? endDateMax = null,
            DateTime? lockDateMin = null,
            DateTime? lockDateMax = null,
            int? calanderYearMin = null,
            int? calanderYearMax = null,
            byte? yearEndMonthMin = null,
            byte? yearEndMonthMax = null,
            byte? yearEndDayMin = null,
            byte? yearEndDayMax = null,
            bool? isCurrent = null,
            bool? isLocked = null,
            byte? noOfPeriodsMin = null,
            byte? noOfPeriodsMax = null,
            string? periodInterval = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.FiscalYearName!.Contains(filterText!) || e.PeriodInterval!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(fiscalYearName), e => e.FiscalYearName.Contains(fiscalYearName))
                    .WhereIf(startDateMin.HasValue, e => e.StartDate >= startDateMin!.Value)
                    .WhereIf(startDateMax.HasValue, e => e.StartDate <= startDateMax!.Value)
                    .WhereIf(endDateMin.HasValue, e => e.EndDate >= endDateMin!.Value)
                    .WhereIf(endDateMax.HasValue, e => e.EndDate <= endDateMax!.Value)
                    .WhereIf(lockDateMin.HasValue, e => e.LockDate >= lockDateMin!.Value)
                    .WhereIf(lockDateMax.HasValue, e => e.LockDate <= lockDateMax!.Value)
                    .WhereIf(calanderYearMin.HasValue, e => e.CalanderYear >= calanderYearMin!.Value)
                    .WhereIf(calanderYearMax.HasValue, e => e.CalanderYear <= calanderYearMax!.Value)

                    .WhereIf(isCurrent.HasValue, e => e.IsCurrent == isCurrent)
                    .WhereIf(isLocked.HasValue, e => e.IsLocked == isLocked)

                    .WhereIf(!string.IsNullOrWhiteSpace(periodInterval), e => e.PeriodInterval.Contains(periodInterval));
        }
    }
}