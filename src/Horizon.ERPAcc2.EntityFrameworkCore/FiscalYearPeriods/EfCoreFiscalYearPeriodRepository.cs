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
    public abstract class EfCoreFiscalYearPeriodRepositoryBase : EfCoreRepository<ERPAcc2DbContext, FiscalYearPeriod, Guid>
    {
        public EfCoreFiscalYearPeriodRepositoryBase(IDbContextProvider<ERPAcc2DbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<FiscalYearPeriod>> GetListByFiscalYearIdAsync(
           Guid fiscalYearId,
           string? sorting = null,
           int maxResultCount = int.MaxValue,
           int skipCount = 0,
           CancellationToken cancellationToken = default)
        {
            var query = (await GetQueryableAsync()).Where(x => x.FiscalYearId == fiscalYearId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? FiscalYearPeriodConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountByFiscalYearIdAsync(Guid fiscalYearId, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync()).Where(x => x.FiscalYearId == fiscalYearId).CountAsync(cancellationToken);
        }

        public virtual async Task<List<FiscalYearPeriod>> GetListAsync(
            string? filterText = null,
            string? periodName = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            DateTime? startDateMin = null,
            DateTime? startDateMax = null,
            DateTime? endDateMin = null,
            DateTime? endDateMax = null,
            int? periodStatusIdMin = null,
            int? periodStatusIdMax = null,
            bool? isClosed = null,
            DateTime? closeDateMin = null,
            DateTime? closeDateMax = null,
            decimal? totalDepitMin = null,
            decimal? totalDepitMax = null,
            decimal? totalCreditMin = null,
            decimal? totalCreditMax = null,
            decimal? closingBalanceMin = null,
            decimal? closingBalanceMax = null,
            decimal? beginingInventoryMin = null,
            decimal? beginingInventoryMax = null,
            decimal? purchasesMin = null,
            decimal? purchasesMax = null,
            decimal? endiningInventoryMin = null,
            decimal? endiningInventoryMax = null,
            decimal? cOGSMin = null,
            decimal? cOGSMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, periodName, companyIdMin, companyIdMax, startDateMin, startDateMax, endDateMin, endDateMax, periodStatusIdMin, periodStatusIdMax, isClosed, closeDateMin, closeDateMax, totalDepitMin, totalDepitMax, totalCreditMin, totalCreditMax, closingBalanceMin, closingBalanceMax, beginingInventoryMin, beginingInventoryMax, purchasesMin, purchasesMax, endiningInventoryMin, endiningInventoryMax, cOGSMin, cOGSMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? FiscalYearPeriodConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? periodName = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            DateTime? startDateMin = null,
            DateTime? startDateMax = null,
            DateTime? endDateMin = null,
            DateTime? endDateMax = null,
            int? periodStatusIdMin = null,
            int? periodStatusIdMax = null,
            bool? isClosed = null,
            DateTime? closeDateMin = null,
            DateTime? closeDateMax = null,
            decimal? totalDepitMin = null,
            decimal? totalDepitMax = null,
            decimal? totalCreditMin = null,
            decimal? totalCreditMax = null,
            decimal? closingBalanceMin = null,
            decimal? closingBalanceMax = null,
            decimal? beginingInventoryMin = null,
            decimal? beginingInventoryMax = null,
            decimal? purchasesMin = null,
            decimal? purchasesMax = null,
            decimal? endiningInventoryMin = null,
            decimal? endiningInventoryMax = null,
            decimal? cOGSMin = null,
            decimal? cOGSMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, periodName, companyIdMin, companyIdMax, startDateMin, startDateMax, endDateMin, endDateMax, periodStatusIdMin, periodStatusIdMax, isClosed, closeDateMin, closeDateMax, totalDepitMin, totalDepitMax, totalCreditMin, totalCreditMax, closingBalanceMin, closingBalanceMax, beginingInventoryMin, beginingInventoryMax, purchasesMin, purchasesMax, endiningInventoryMin, endiningInventoryMax, cOGSMin, cOGSMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<FiscalYearPeriod> ApplyFilter(
            IQueryable<FiscalYearPeriod> query,
            string? filterText = null,
            string? periodName = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            DateTime? startDateMin = null,
            DateTime? startDateMax = null,
            DateTime? endDateMin = null,
            DateTime? endDateMax = null,
            int? periodStatusIdMin = null,
            int? periodStatusIdMax = null,
            bool? isClosed = null,
            DateTime? closeDateMin = null,
            DateTime? closeDateMax = null,
            decimal? totalDepitMin = null,
            decimal? totalDepitMax = null,
            decimal? totalCreditMin = null,
            decimal? totalCreditMax = null,
            decimal? closingBalanceMin = null,
            decimal? closingBalanceMax = null,
            decimal? beginingInventoryMin = null,
            decimal? beginingInventoryMax = null,
            decimal? purchasesMin = null,
            decimal? purchasesMax = null,
            decimal? endiningInventoryMin = null,
            decimal? endiningInventoryMax = null,
            decimal? cOGSMin = null,
            decimal? cOGSMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.PeriodName!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(periodName), e => e.PeriodName.Contains(periodName))
                    .WhereIf(companyIdMin.HasValue, e => e.CompanyId >= companyIdMin!.Value)
                    .WhereIf(companyIdMax.HasValue, e => e.CompanyId <= companyIdMax!.Value)
                    .WhereIf(startDateMin.HasValue, e => e.StartDate >= startDateMin!.Value)
                    .WhereIf(startDateMax.HasValue, e => e.StartDate <= startDateMax!.Value)
                    .WhereIf(endDateMin.HasValue, e => e.EndDate >= endDateMin!.Value)
                    .WhereIf(endDateMax.HasValue, e => e.EndDate <= endDateMax!.Value)
                    .WhereIf(periodStatusIdMin.HasValue, e => e.PeriodStatusId >= periodStatusIdMin!.Value)
                    .WhereIf(periodStatusIdMax.HasValue, e => e.PeriodStatusId <= periodStatusIdMax!.Value)
                    .WhereIf(isClosed.HasValue, e => e.IsClosed == isClosed)
                    .WhereIf(closeDateMin.HasValue, e => e.CloseDate >= closeDateMin!.Value)
                    .WhereIf(closeDateMax.HasValue, e => e.CloseDate <= closeDateMax!.Value)
                    .WhereIf(totalDepitMin.HasValue, e => e.TotalDepit >= totalDepitMin!.Value)
                    .WhereIf(totalDepitMax.HasValue, e => e.TotalDepit <= totalDepitMax!.Value)
                    .WhereIf(totalCreditMin.HasValue, e => e.TotalCredit >= totalCreditMin!.Value)
                    .WhereIf(totalCreditMax.HasValue, e => e.TotalCredit <= totalCreditMax!.Value)
                    .WhereIf(closingBalanceMin.HasValue, e => e.ClosingBalance >= closingBalanceMin!.Value)
                    .WhereIf(closingBalanceMax.HasValue, e => e.ClosingBalance <= closingBalanceMax!.Value)
                    .WhereIf(beginingInventoryMin.HasValue, e => e.BeginingInventory >= beginingInventoryMin!.Value)
                    .WhereIf(beginingInventoryMax.HasValue, e => e.BeginingInventory <= beginingInventoryMax!.Value)
                    .WhereIf(purchasesMin.HasValue, e => e.Purchases >= purchasesMin!.Value)
                    .WhereIf(purchasesMax.HasValue, e => e.Purchases <= purchasesMax!.Value)
                    .WhereIf(endiningInventoryMin.HasValue, e => e.EndiningInventory >= endiningInventoryMin!.Value)
                    .WhereIf(endiningInventoryMax.HasValue, e => e.EndiningInventory <= endiningInventoryMax!.Value)
                    .WhereIf(cOGSMin.HasValue, e => e.COGS >= cOGSMin!.Value)
                    .WhereIf(cOGSMax.HasValue, e => e.COGS <= cOGSMax!.Value);
        }
    }
}