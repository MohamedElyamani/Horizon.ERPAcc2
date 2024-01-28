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

namespace Horizon.ERPAcc2.FiscalYearStatuses
{
    public abstract class EfCoreFiscalYearStatusRepositoryBase : EfCoreRepository<ERPAcc2DbContext, FiscalYearStatus, int>
    {
        public EfCoreFiscalYearStatusRepositoryBase(IDbContextProvider<ERPAcc2DbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<FiscalYearStatus>> GetListAsync(
            string? filterText = null,
            string? fiscalYearStatusTitle = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, fiscalYearStatusTitle);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? FiscalYearStatusConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? fiscalYearStatusTitle = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, fiscalYearStatusTitle);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<FiscalYearStatus> ApplyFilter(
            IQueryable<FiscalYearStatus> query,
            string? filterText = null,
            string? fiscalYearStatusTitle = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.FiscalYearStatusTitle!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(fiscalYearStatusTitle), e => e.FiscalYearStatusTitle.Contains(fiscalYearStatusTitle));
        }
    }
}