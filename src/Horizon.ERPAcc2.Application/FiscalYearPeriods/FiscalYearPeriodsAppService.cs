using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Horizon.ERPAcc2.Permissions;
using Horizon.ERPAcc2.FiscalYearPeriods;

namespace Horizon.ERPAcc2.FiscalYearPeriods
{

    [Authorize(ERPAcc2Permissions.FiscalYearPeriods.Default)]
    public abstract class FiscalYearPeriodsAppServiceBase : ApplicationService
    {

        protected IFiscalYearPeriodRepository _fiscalYearPeriodRepository;
        protected FiscalYearPeriodManager _fiscalYearPeriodManager;

        public FiscalYearPeriodsAppServiceBase(IFiscalYearPeriodRepository fiscalYearPeriodRepository, FiscalYearPeriodManager fiscalYearPeriodManager)
        {

            _fiscalYearPeriodRepository = fiscalYearPeriodRepository;
            _fiscalYearPeriodManager = fiscalYearPeriodManager;
        }

        public virtual async Task<PagedResultDto<FiscalYearPeriodDto>> GetListByFiscalYearIdAsync(GetFiscalYearPeriodListInput input)
        {
            var fiscalYearPeriods = await _fiscalYearPeriodRepository.GetListByFiscalYearIdAsync(
                input.FiscalYearId,
                input.Sorting,
                input.MaxResultCount,
                input.SkipCount);

            return new PagedResultDto<FiscalYearPeriodDto>
            {
                TotalCount = await _fiscalYearPeriodRepository.GetCountByFiscalYearIdAsync(input.FiscalYearId),
                Items = ObjectMapper.Map<List<FiscalYearPeriod>, List<FiscalYearPeriodDto>>(fiscalYearPeriods)
            };
        }

        public virtual async Task<PagedResultDto<FiscalYearPeriodDto>> GetListAsync(GetFiscalYearPeriodsInput input)
        {
            var totalCount = await _fiscalYearPeriodRepository.GetCountAsync(input.FilterText, input.PeriodName, input.CompanyIdMin, input.CompanyIdMax, input.StartDateMin, input.StartDateMax, input.EndDateMin, input.EndDateMax, input.PeriodStatusIdMin, input.PeriodStatusIdMax, input.IsClosed, input.CloseDateMin, input.CloseDateMax, input.TotalDepitMin, input.TotalDepitMax, input.TotalCreditMin, input.TotalCreditMax, input.ClosingBalanceMin, input.ClosingBalanceMax, input.BeginingInventoryMin, input.BeginingInventoryMax, input.PurchasesMin, input.PurchasesMax, input.EndiningInventoryMin, input.EndiningInventoryMax, input.COGSMin, input.COGSMax);
            var items = await _fiscalYearPeriodRepository.GetListAsync(input.FilterText, input.PeriodName, input.CompanyIdMin, input.CompanyIdMax, input.StartDateMin, input.StartDateMax, input.EndDateMin, input.EndDateMax, input.PeriodStatusIdMin, input.PeriodStatusIdMax, input.IsClosed, input.CloseDateMin, input.CloseDateMax, input.TotalDepitMin, input.TotalDepitMax, input.TotalCreditMin, input.TotalCreditMax, input.ClosingBalanceMin, input.ClosingBalanceMax, input.BeginingInventoryMin, input.BeginingInventoryMax, input.PurchasesMin, input.PurchasesMax, input.EndiningInventoryMin, input.EndiningInventoryMax, input.COGSMin, input.COGSMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<FiscalYearPeriodDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<FiscalYearPeriod>, List<FiscalYearPeriodDto>>(items)
            };
        }

        public virtual async Task<FiscalYearPeriodDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<FiscalYearPeriod, FiscalYearPeriodDto>(await _fiscalYearPeriodRepository.GetAsync(id));
        }

        [Authorize(ERPAcc2Permissions.FiscalYearPeriods.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _fiscalYearPeriodRepository.DeleteAsync(id);
        }

        [Authorize(ERPAcc2Permissions.FiscalYearPeriods.Create)]
        public virtual async Task<FiscalYearPeriodDto> CreateAsync(FiscalYearPeriodCreateDto input)
        {

            var fiscalYearPeriod = await _fiscalYearPeriodManager.CreateAsync(input.FiscalYearId,
            input.PeriodName, input.CompanyId, input.StartDate, input.EndDate, input.PeriodStatusId, input.IsClosed, input.TotalDepit, input.TotalCredit, input.ClosingBalance, input.BeginingInventory, input.Purchases, input.EndiningInventory, input.COGS, input.CloseDate
            );

            return ObjectMapper.Map<FiscalYearPeriod, FiscalYearPeriodDto>(fiscalYearPeriod);
        }

        [Authorize(ERPAcc2Permissions.FiscalYearPeriods.Edit)]
        public virtual async Task<FiscalYearPeriodDto> UpdateAsync(Guid id, FiscalYearPeriodUpdateDto input)
        {

            var fiscalYearPeriod = await _fiscalYearPeriodManager.UpdateAsync(
            id, input.FiscalYearId,
            input.PeriodName, input.CompanyId, input.StartDate, input.EndDate, input.PeriodStatusId, input.IsClosed, input.TotalDepit, input.TotalCredit, input.ClosingBalance, input.BeginingInventory, input.Purchases, input.EndiningInventory, input.COGS, input.CloseDate
            );

            return ObjectMapper.Map<FiscalYearPeriod, FiscalYearPeriodDto>(fiscalYearPeriod);
        }
    }
}