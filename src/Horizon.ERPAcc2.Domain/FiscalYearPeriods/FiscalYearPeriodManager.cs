using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Horizon.ERPAcc2.FiscalYearPeriods
{
    public abstract class FiscalYearPeriodManagerBase : DomainService
    {
        protected IFiscalYearPeriodRepository _fiscalYearPeriodRepository;

        public FiscalYearPeriodManagerBase(IFiscalYearPeriodRepository fiscalYearPeriodRepository)
        {
            _fiscalYearPeriodRepository = fiscalYearPeriodRepository;
        }

        public virtual async Task<FiscalYearPeriod> CreateAsync(
        Guid fiscalYearId, string periodName, int companyId, DateTime startDate, DateTime endDate, int periodStatusId, bool isClosed, decimal totalDepit, decimal totalCredit, decimal closingBalance, decimal beginingInventory, decimal purchases, decimal endiningInventory, decimal cOGS, DateTime? closeDate = null)
        {
            Check.NotNullOrWhiteSpace(periodName, nameof(periodName));
            Check.Length(periodName, nameof(periodName), FiscalYearPeriodConsts.PeriodNameMaxLength);
            Check.NotNull(startDate, nameof(startDate));
            Check.NotNull(endDate, nameof(endDate));

            var fiscalYearPeriod = new FiscalYearPeriod(
             GuidGenerator.Create(),
             fiscalYearId, periodName, companyId, startDate, endDate, periodStatusId, isClosed, totalDepit, totalCredit, closingBalance, beginingInventory, purchases, endiningInventory, cOGS, closeDate
             );

            return await _fiscalYearPeriodRepository.InsertAsync(fiscalYearPeriod);
        }

        public virtual async Task<FiscalYearPeriod> UpdateAsync(
            Guid id,
            Guid fiscalYearId, string periodName, int companyId, DateTime startDate, DateTime endDate, int periodStatusId, bool isClosed, decimal totalDepit, decimal totalCredit, decimal closingBalance, decimal beginingInventory, decimal purchases, decimal endiningInventory, decimal cOGS, DateTime? closeDate = null
        )
        {
            Check.NotNullOrWhiteSpace(periodName, nameof(periodName));
            Check.Length(periodName, nameof(periodName), FiscalYearPeriodConsts.PeriodNameMaxLength);
            Check.NotNull(startDate, nameof(startDate));
            Check.NotNull(endDate, nameof(endDate));

            var fiscalYearPeriod = await _fiscalYearPeriodRepository.GetAsync(id);

            fiscalYearPeriod.FiscalYearId = fiscalYearId;
            fiscalYearPeriod.PeriodName = periodName;
            fiscalYearPeriod.CompanyId = companyId;
            fiscalYearPeriod.StartDate = startDate;
            fiscalYearPeriod.EndDate = endDate;
            fiscalYearPeriod.PeriodStatusId = periodStatusId;
            fiscalYearPeriod.IsClosed = isClosed;
            fiscalYearPeriod.TotalDepit = totalDepit;
            fiscalYearPeriod.TotalCredit = totalCredit;
            fiscalYearPeriod.ClosingBalance = closingBalance;
            fiscalYearPeriod.BeginingInventory = beginingInventory;
            fiscalYearPeriod.Purchases = purchases;
            fiscalYearPeriod.EndiningInventory = endiningInventory;
            fiscalYearPeriod.COGS = cOGS;
            fiscalYearPeriod.CloseDate = closeDate;

            return await _fiscalYearPeriodRepository.UpdateAsync(fiscalYearPeriod);
        }

    }
}